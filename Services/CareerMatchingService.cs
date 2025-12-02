using System;
using System.Collections.Generic;
using System.Linq;
using UWCApplicationForm.Models;

namespace UWCApplicationForm.Services
{
    public class CareerMatchingService
    {
        public CareerRecommendation GenerateRecommendations(StudentAcademicProfile profile)
        {
            var recommendation = new CareerRecommendation
            {
                StudentProfile = profile,
                GeneratedDate = DateTime.Now
            };

            // Calculate category strengths
            recommendation.CategoryStrengths = CalculateCategoryStrengths(profile);

            // Get all careers and calculate match scores
            var allCareers = CareerDataRepository.GetAllCareers();
            foreach (var career in allCareers)
            {
                career.MatchScore = CalculateMatchScore(profile, career, recommendation.CategoryStrengths);
                career.MatchReason = GenerateMatchReason(profile, career);
            }

            // Sort by match score
            var sortedCareers = allCareers.OrderByDescending(c => c.MatchScore).ToList();

            // Top recommendations (70%+ match)
            recommendation.RecommendedCareers = sortedCareers.Where(c => c.MatchScore >= 70).Take(5).ToList();

            // Alternative careers (50-69% match)
            recommendation.AlternativeCareers = sortedCareers.Where(c => c.MatchScore >= 50 && c.MatchScore < 70).Take(5).ToList();

            // Generate summary statistics
            recommendation.PerformanceLevel = GetPerformanceLevel(profile.OverallAverage);
            recommendation.TopSubjects = GetTopSubjects(profile);
            recommendation.ImprovementAreas = GetImprovementAreas(profile);
            recommendation.GeneralRecommendations = GenerateGeneralRecommendations(profile, recommendation);

            return recommendation;
        }

        private Dictionary<SubjectCategory, double> CalculateCategoryStrengths(StudentAcademicProfile profile)
        {
            var strengths = new Dictionary<SubjectCategory, double>();

            var categories = Enum.GetValues(typeof(SubjectCategory)).Cast<SubjectCategory>();
            foreach (var category in categories)
            {
                var categorySubjects = profile.Subjects.Where(s => s.Category == category).ToList();
                if (categorySubjects.Any())
                {
                    strengths[category] = categorySubjects.Average(s => s.Mark);
                }
                else
                {
                    strengths[category] = 0;
                }
            }

            return strengths;
        }

        private double CalculateMatchScore(StudentAcademicProfile profile, CareerPath career, Dictionary<SubjectCategory, double> categoryStrengths)
        {
            double totalScore = 0;
            int factors = 0;

            // Factor 1: Overall average vs minimum requirement (30% weight)
            if (profile.OverallAverage >= career.MinimumAverageRequired)
            {
                totalScore += 30;
            }
            else
            {
                double percentageOfRequirement = (profile.OverallAverage / career.MinimumAverageRequired) * 30;
                totalScore += Math.Max(0, percentageOfRequirement);
            }
            factors++;

            // Factor 2: Required subject minimums (30% weight)
            double subjectScore = 0;
            int subjectCount = 0;
            foreach (var reqSubject in career.SubjectMinimums)
            {
                var studentSubject = profile.Subjects.FirstOrDefault(s => 
                    s.SubjectName.Equals(reqSubject.Key, StringComparison.OrdinalIgnoreCase));
                
                if (studentSubject != null)
                {
                    if (studentSubject.Mark >= reqSubject.Value)
                    {
                        subjectScore += 10;
                    }
                    else
                    {
                        subjectScore += (studentSubject.Mark / (double)reqSubject.Value) * 10;
                    }
                    subjectCount++;
                }
            }
            
            if (subjectCount > 0)
            {
                totalScore += (subjectScore / subjectCount) * 3; // Max 30 points
            }
            factors++;

            // Factor 3: Category strength alignment (25% weight)
            double categoryScore = 0;
            if (career.RequiredStrengths.Any())
            {
                foreach (var strength in career.RequiredStrengths)
                {
                    if (categoryStrengths.ContainsKey(strength))
                    {
                        categoryScore += categoryStrengths[strength] / 100.0 * 25.0 / career.RequiredStrengths.Count;
                    }
                }
                totalScore += categoryScore;
            }
            else
            {
                totalScore += 15; // Neutral score if no specific requirements
            }
            factors++;

            // Factor 4: Interest alignment (15% weight)
            double interestScore = 0;
            foreach (var interest in profile.Interests)
            {
                if (career.RequiredStrengths.Contains(interest.RelatedCategory))
                {
                    interestScore += interest.InterestLevel * 3.0;
                }
            }
            totalScore += Math.Min(15, interestScore);
            factors++;

            return Math.Min(100, totalScore);
        }

        private string GenerateMatchReason(StudentAcademicProfile profile, CareerPath career)
        {
            var reasons = new List<string>();

            // Check overall average
            if (profile.OverallAverage >= career.MinimumAverageRequired)
            {
                reasons.Add($"Your overall average ({profile.OverallAverage:F1}%) exceeds the requirement");
            }

            // Check subject performance
            foreach (var reqSubject in career.SubjectMinimums)
            {
                var studentSubject = profile.Subjects.FirstOrDefault(s => 
                    s.SubjectName.Equals(reqSubject.Key, StringComparison.OrdinalIgnoreCase));
                
                if (studentSubject != null && studentSubject.Mark >= reqSubject.Value)
                {
                    reasons.Add($"Strong performance in {studentSubject.SubjectName} ({studentSubject.Mark}%)");
                }
            }

            // Check category strengths
            var categoryStrengths = CalculateCategoryStrengths(profile);
            foreach (var strength in career.RequiredStrengths)
            {
                if (categoryStrengths.ContainsKey(strength) && categoryStrengths[strength] >= 70)
                {
                    reasons.Add($"Strong {strength} skills");
                }
            }

            // Check interests
            var matchingInterests = profile.Interests.Where(i => 
                career.RequiredStrengths.Contains(i.RelatedCategory) && i.InterestLevel >= 4).ToList();
            
            if (matchingInterests.Any())
            {
                reasons.Add($"High interest in related areas");
            }

            return reasons.Any() ? string.Join("; ", reasons) : "General match based on profile";
        }

        private string GetPerformanceLevel(double average)
        {
            if (average >= 80) return "Outstanding";
            if (average >= 70) return "Excellent";
            if (average >= 60) return "Good";
            if (average >= 50) return "Satisfactory";
            return "Needs Improvement";
        }

        private List<string> GetTopSubjects(StudentAcademicProfile profile)
        {
            return profile.Subjects
                .OrderByDescending(s => s.Mark)
                .Take(3)
                .Select(s => $"{s.SubjectName} ({s.Mark}%)")
                .ToList();
        }

        private List<string> GetImprovementAreas(StudentAcademicProfile profile)
        {
            return profile.Subjects
                .Where(s => s.Mark < 60)
                .OrderBy(s => s.Mark)
                .Take(3)
                .Select(s => $"{s.SubjectName} ({s.Mark}%)")
                .ToList();
        }

        private List<string> GenerateGeneralRecommendations(StudentAcademicProfile profile, CareerRecommendation recommendation)
        {
            var recommendations = new List<string>();

            // Performance-based recommendations
            if (profile.OverallAverage >= 75)
            {
                recommendations.Add("Your strong academic performance opens doors to competitive fields like Medicine, Engineering, and Law.");
            }
            else if (profile.OverallAverage >= 60)
            {
                recommendations.Add("With focused effort, you can qualify for most university programs. Consider additional study in weaker subjects.");
            }
            else
            {
                recommendations.Add("Consider vocational training or foundation programs to strengthen your academic base.");
            }

            // Subject category recommendations
            var topCategory = recommendation.CategoryStrengths.OrderByDescending(c => c.Value).FirstOrDefault();
            if (topCategory.Value >= 70)
            {
                recommendations.Add($"Your strength in {topCategory.Key} opens opportunities in related career fields.");
            }

            // Interest-based recommendations
            if (profile.Interests.Any(i => i.InterestLevel >= 4))
            {
                recommendations.Add("Follow your passions - careers aligned with your interests lead to greater satisfaction and success.");
            }

            // General career advice
            recommendations.Add("Consider internships, job shadowing, and career talks to explore options firsthand.");
            recommendations.Add("Remember: Hard work and determination can help you achieve your goals regardless of current marks.");
            
            // University preparation
            if (profile.CurrentLevel == EducationLevel.HighSchool)
            {
                if (profile.OverallAverage >= 70)
                {
                    recommendations.Add("Start researching universities and their admission requirements for your preferred programs.");
                }
                recommendations.Add("Participate in extracurricular activities to strengthen your university applications.");
            }

            // Skills development
            recommendations.Add("Develop soft skills like communication, teamwork, and leadership - they're valued in all careers.");

            return recommendations;
        }

        public Dictionary<string, object> GetCareerStatistics(List<CareerPath> careers)
        {
            var stats = new Dictionary<string, object>();

            if (!careers.Any()) return stats;

            // Average salaries
            stats["AvgEntrySalary"] = "R250,000 - R400,000";
            stats["AvgMidCareerSalary"] = "R500,000 - R800,000";
            stats["AvgSeniorSalary"] = "R900,000 - R1,500,000";

            // Field distribution
            var fieldCounts = careers.GroupBy(c => c.Field)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key.ToString(), g => g.Count());
            stats["TopFields"] = fieldCounts;

            // Study duration
            stats["AvgYearsOfStudy"] = careers.Average(c => c.YearsOfStudy);

            return stats;
        }

        public List<string> GetStudyTips(SubjectCategory category)
        {
            var tips = new Dictionary<SubjectCategory, List<string>>
            {
                [SubjectCategory.Mathematics] = new()
                {
                    "Practice daily - mathematics requires consistent practice",
                    "Understand concepts, don't just memorize formulas",
                    "Work through past papers to identify common question types",
                    "Form study groups to learn from peers",
                    "Use online resources like Khan Academy for extra help"
                },
                [SubjectCategory.Science] = new()
                {
                    "Do practical experiments to understand concepts better",
                    "Create visual diagrams and mind maps",
                    "Study in chunks - science requires deep understanding",
                    "Watch science documentaries to see real-world applications",
                    "Practice explaining concepts in your own words"
                },
                [SubjectCategory.Languages] = new()
                {
                    "Read widely - novels, newspapers, magazines",
                    "Practice writing essays regularly",
                    "Build your vocabulary through reading and word games",
                    "Join debate clubs to improve communication skills",
                    "Listen to podcasts and watch movies in the language"
                },
                [SubjectCategory.Commerce] = new()
                {
                    "Stay updated with current economic and business news",
                    "Understand real-world applications of concepts",
                    "Practice calculations and financial statements",
                    "Create summary notes for each topic",
                    "Use case studies to understand business scenarios"
                },
                [SubjectCategory.Technology] = new()
                {
                    "Get hands-on practice with software and tools",
                    "Build personal projects to apply your knowledge",
                    "Watch online tutorials and coding videos",
                    "Join tech communities and forums",
                    "Stay current with technology trends"
                }
            };

            return tips.ContainsKey(category) ? tips[category] : new List<string>();
        }
    }
}
