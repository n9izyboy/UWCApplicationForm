using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UWCApplicationForm.Models
{
    // Education levels
    public enum EducationLevel
    {
        PrimarySchool,
        HighSchool,
        Undergraduate
    }

    // Subject categories
    public enum SubjectCategory
    {
        Mathematics,
        Science,
        Languages,
        Humanities,
        Arts,
        Commerce,
        Technology
    }

    // Career fields
    public enum CareerField
    {
        Engineering,
        Medicine,
        Law,
        Business,
        Education,
        Arts,
        Technology,
        Science,
        Healthcare,
        Finance,
        Architecture,
        Agriculture,
        Media,
        SocialSciences
    }

    // Student subject performance
    public class SubjectPerformance
    {
        public string SubjectName { get; set; } = string.Empty;
        public SubjectCategory Category { get; set; }
        public int Mark { get; set; } // Out of 100
        public string Grade { get; set; } = string.Empty;
        public int Credits { get; set; } = 3;
    }

    // Student interests
    public class StudentInterest
    {
        public string InterestName { get; set; } = string.Empty;
        public int InterestLevel { get; set; } // 1-5 scale
        public SubjectCategory RelatedCategory { get; set; }
    }

    // Student academic profile
    public class StudentAcademicProfile
    {
        public string StudentName { get; set; } = string.Empty;
        public EducationLevel CurrentLevel { get; set; }
        public int CurrentGrade { get; set; }
        public List<SubjectPerformance> Subjects { get; set; } = new();
        public List<StudentInterest> Interests { get; set; } = new();
        public List<string> Strengths { get; set; } = new();
        public List<string> Weaknesses { get; set; } = new();
        
        // Calculated properties
        public double OverallAverage => Subjects.Count > 0 
            ? Subjects.Average(s => s.Mark) 
            : 0;
        
        public double WeightedAverage => Subjects.Count > 0 
            ? Subjects.Sum(s => s.Mark * s.Credits) / (double)Subjects.Sum(s => s.Credits)
            : 0;
    }

    // Career certification
    public class Certification
    {
        public string Name { get; set; } = string.Empty;
        public string IssuingBody { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
    }

    // Career path details
    public class CareerPath
    {
        public string CareerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CareerField Field { get; set; }
        public List<SubjectCategory> RequiredStrengths { get; set; } = new();
        public List<string> RequiredSubjects { get; set; } = new();
        public int MinimumAverageRequired { get; set; } // Percentage
        public Dictionary<string, int> SubjectMinimums { get; set; } = new(); // Subject name -> minimum mark
        
        // Education requirements
        public string MinimumEducation { get; set; } = string.Empty;
        public List<string> RecommendedDegrees { get; set; } = new();
        public int YearsOfStudy { get; set; }
        
        // Certifications
        public List<Certification> Certifications { get; set; } = new();
        
        // Career prospects
        public string EntrySalaryRange { get; set; } = string.Empty; // e.g., "R250,000 - R350,000"
        public string MidCareerSalaryRange { get; set; } = string.Empty;
        public string SeniorSalaryRange { get; set; } = string.Empty;
        public string JobOutlook { get; set; } = string.Empty; // Growth prospects
        public List<string> TypicalRoles { get; set; } = new();
        
        // Interesting facts
        public List<string> InterestingFacts { get; set; } = new();
        public List<string> DailyActivities { get; set; } = new();
        public List<string> RequiredSkills { get; set; } = new();
        public List<string> WorkEnvironments { get; set; } = new();
        
        // Match score (calculated)
        public double MatchScore { get; set; }
        public string MatchReason { get; set; } = string.Empty;
    }

    // Career recommendation result
    public class CareerRecommendation
    {
        public StudentAcademicProfile StudentProfile { get; set; } = new();
        public List<CareerPath> RecommendedCareers { get; set; } = new();
        public List<CareerPath> AlternativeCareers { get; set; } = new();
        public Dictionary<SubjectCategory, double> CategoryStrengths { get; set; } = new();
        public List<string> GeneralRecommendations { get; set; } = new();
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
        
        // Summary statistics
        public string PerformanceLevel { get; set; } = string.Empty; // Excellent, Good, Average, etc.
        public List<string> TopSubjects { get; set; } = new();
        public List<string> ImprovementAreas { get; set; } = new();
    }

    // Quick assessment questions
    public class AssessmentQuestion
    {
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public SubjectCategory RelatedCategory { get; set; }
    }
}
