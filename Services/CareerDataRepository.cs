using System;
using System.Collections.Generic;
using System.Linq;
using UWCApplicationForm.Models;

namespace UWCApplicationForm.Services
{
    public class CareerDataRepository
    {
        private static List<CareerPath>? _careerPaths;

        public static List<CareerPath> GetAllCareers()
        {
            if (_careerPaths != null) return _careerPaths;

            _careerPaths = new List<CareerPath>
            {
                // ENGINEERING CAREERS
                new CareerPath
                {
                    CareerName = "Software Engineer",
                    Description = "Design, develop, and maintain software applications and systems using programming languages and frameworks.",
                    Field = CareerField.Technology,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Technology },
                    RequiredSubjects = new() { "Mathematics", "Physical Sciences" },
                    MinimumAverageRequired = 65,
                    SubjectMinimums = new() { { "Mathematics", 70 }, { "Physical Sciences", 65 } },
                    MinimumEducation = "Bachelor's Degree in Computer Science or Software Engineering",
                    RecommendedDegrees = new() { "BSc Computer Science", "BEng Software Engineering", "BSc Information Technology" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Professional Registration (ECSA)", IssuingBody = "Engineering Council of South Africa", Duration = "After graduation", IsRequired = false },
                        new Certification { Name = "AWS Certified Developer", IssuingBody = "Amazon Web Services", Duration = "3-6 months", IsRequired = false },
                        new Certification { Name = "Microsoft Certified: Azure Developer", IssuingBody = "Microsoft", Duration = "3-6 months", IsRequired = false }
                    },
                    EntrySalaryRange = "R280,000 - R450,000",
                    MidCareerSalaryRange = "R550,000 - R850,000",
                    SeniorSalaryRange = "R900,000 - R1,500,000+",
                    JobOutlook = "Excellent - High demand with 15-20% growth expected",
                    TypicalRoles = new() { "Junior Developer", "Full Stack Developer", "Software Architect", "Tech Lead", "CTO" },
                    InterestingFacts = new()
                    {
                        "The first computer programmer was Ada Lovelace in 1843, over 100 years before computers existed!",
                        "Software engineers can work from anywhere in the world with just a laptop and internet connection",
                        "The global shortage of software engineers means high salaries and job security",
                        "Many successful tech companies like Google and Facebook were started by software engineers in their 20s"
                    },
                    DailyActivities = new() { "Writing and testing code", "Collaborating with team members", "Problem-solving and debugging", "Learning new technologies", "Code reviews and documentation" },
                    RequiredSkills = new() { "Programming (Python, Java, C++)", "Problem-solving", "Logical thinking", "Teamwork", "Continuous learning" },
                    WorkEnvironments = new() { "Tech companies", "Startups", "Banks and financial institutions", "Remote work", "Consulting firms" }
                },

                new CareerPath
                {
                    CareerName = "Civil Engineer",
                    Description = "Design and oversee construction of infrastructure projects like roads, bridges, buildings, and water systems.",
                    Field = CareerField.Engineering,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Science },
                    RequiredSubjects = new() { "Mathematics", "Physical Sciences" },
                    MinimumAverageRequired = 70,
                    SubjectMinimums = new() { { "Mathematics", 75 }, { "Physical Sciences", 70 } },
                    MinimumEducation = "Bachelor's Degree in Civil Engineering (BEng)",
                    RecommendedDegrees = new() { "BEng Civil Engineering", "BSc Civil Engineering" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Professional Engineer (Pr Eng)", IssuingBody = "ECSA", Duration = "4 years work experience", IsRequired = true },
                        new Certification { Name = "Project Management Professional", IssuingBody = "PMI", Duration = "6 months", IsRequired = false }
                    },
                    EntrySalaryRange = "R300,000 - R420,000",
                    MidCareerSalaryRange = "R500,000 - R750,000",
                    SeniorSalaryRange = "R800,000 - R1,200,000",
                    JobOutlook = "Good - Infrastructure development drives demand",
                    TypicalRoles = new() { "Site Engineer", "Structural Engineer", "Project Manager", "Consulting Engineer", "Construction Manager" },
                    InterestingFacts = new()
                    {
                        "The Burj Khalifa in Dubai stands 828 meters tall - a marvel of civil engineering!",
                        "Ancient Roman roads built 2000 years ago are still used today",
                        "Civil engineers literally shape the world we live in",
                        "South Africa needs thousands of civil engineers for infrastructure development"
                    },
                    DailyActivities = new() { "Designing structures using CAD software", "Site inspections", "Project planning", "Team meetings", "Budget management" },
                    RequiredSkills = new() { "Technical drawing", "Mathematics", "Problem-solving", "Project management", "Attention to detail" },
                    WorkEnvironments = new() { "Construction sites", "Engineering offices", "Government departments", "Consulting firms" }
                },

                // MEDICAL CAREERS
                new CareerPath
                {
                    CareerName = "Medical Doctor",
                    Description = "Diagnose and treat illnesses, injuries, and diseases to improve patient health and save lives.",
                    Field = CareerField.Medicine,
                    RequiredStrengths = new() { SubjectCategory.Science, SubjectCategory.Mathematics },
                    RequiredSubjects = new() { "Life Sciences", "Physical Sciences", "Mathematics" },
                    MinimumAverageRequired = 80,
                    SubjectMinimums = new() { { "Life Sciences", 85 }, { "Physical Sciences", 80 }, { "Mathematics", 75 } },
                    MinimumEducation = "MBChB (Bachelor of Medicine and Bachelor of Surgery)",
                    RecommendedDegrees = new() { "MBChB (6 years)", "Specialist training (additional 4-6 years)" },
                    YearsOfStudy = 6,
                    Certifications = new()
                    {
                        new Certification { Name = "Medical License", IssuingBody = "HPCSA", Duration = "After internship", IsRequired = true },
                        new Certification { Name = "Specialist Registration", IssuingBody = "HPCSA", Duration = "4-6 years", IsRequired = false }
                    },
                    EntrySalaryRange = "R400,000 - R600,000",
                    MidCareerSalaryRange = "R800,000 - R1,500,000",
                    SeniorSalaryRange = "R1,500,000 - R3,000,000+",
                    JobOutlook = "Excellent - Always in high demand",
                    TypicalRoles = new() { "Intern Doctor", "General Practitioner", "Specialist (Surgeon, Cardiologist, etc.)", "Medical Researcher", "Hospital Administrator" },
                    InterestingFacts = new()
                    {
                        "Doctors save approximately 70,000 lives per doctor over their career",
                        "The human body has 37.2 trillion cells that doctors help keep healthy",
                        "Medical knowledge doubles every 73 days!",
                        "Dr. Christiaan Barnard performed the world's first heart transplant in Cape Town in 1967"
                    },
                    DailyActivities = new() { "Examining patients", "Diagnosing conditions", "Prescribing treatment", "Performing procedures", "Consulting with colleagues", "Continuing medical education" },
                    RequiredSkills = new() { "Scientific knowledge", "Critical thinking", "Compassion", "Communication", "Resilience", "Decision-making under pressure" },
                    WorkEnvironments = new() { "Hospitals", "Private practices", "Clinics", "Research facilities", "Emergency rooms" }
                },

                new CareerPath
                {
                    CareerName = "Pharmacist",
                    Description = "Dispense medications and provide healthcare advice about proper medication use and potential side effects.",
                    Field = CareerField.Healthcare,
                    RequiredStrengths = new() { SubjectCategory.Science, SubjectCategory.Mathematics },
                    RequiredSubjects = new() { "Life Sciences", "Physical Sciences", "Mathematics" },
                    MinimumAverageRequired = 70,
                    SubjectMinimums = new() { { "Life Sciences", 75 }, { "Physical Sciences", 70 }, { "Mathematics", 65 } },
                    MinimumEducation = "Bachelor of Pharmacy (BPharm)",
                    RecommendedDegrees = new() { "BPharm (4 years)", "MPharm (optional)" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Pharmacist Registration", IssuingBody = "South African Pharmacy Council", Duration = "After internship", IsRequired = true }
                    },
                    EntrySalaryRange = "R250,000 - R400,000",
                    MidCareerSalaryRange = "R450,000 - R650,000",
                    SeniorSalaryRange = "R700,000 - R1,000,000",
                    JobOutlook = "Very Good - Healthcare expansion drives demand",
                    TypicalRoles = new() { "Community Pharmacist", "Hospital Pharmacist", "Clinical Pharmacist", "Pharmaceutical Sales", "Pharmacy Manager" },
                    InterestingFacts = new()
                    {
                        "Pharmacists are medication experts and often catch doctors' prescription errors",
                        "The pharmacy symbol (Bowl of Hygieia) dates back to ancient Greece",
                        "Pharmacists undergo 6 years of training including internship",
                        "They are one of the most accessible healthcare professionals"
                    },
                    DailyActivities = new() { "Dispensing medications", "Counseling patients", "Checking prescriptions", "Managing inventory", "Advising on medication interactions" },
                    RequiredSkills = new() { "Attention to detail", "Chemistry knowledge", "Communication", "Patient care", "Organization" },
                    WorkEnvironments = new() { "Retail pharmacies", "Hospitals", "Clinics", "Pharmaceutical companies", "Research labs" }
                },

                // BUSINESS & FINANCE
                new CareerPath
                {
                    CareerName = "Chartered Accountant (CA)",
                    Description = "Provide financial advice, auditing, taxation, and business consulting services to organizations.",
                    Field = CareerField.Finance,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Commerce },
                    RequiredSubjects = new() { "Mathematics", "Accounting" },
                    MinimumAverageRequired = 70,
                    SubjectMinimums = new() { { "Mathematics", 75 }, { "Accounting", 75 } },
                    MinimumEducation = "BCom Accounting + CTA + Articles",
                    RecommendedDegrees = new() { "BCom Accounting (3 years)", "CTA (1 year)", "Articles (3 years)" },
                    YearsOfStudy = 7,
                    Certifications = new()
                    {
                        new Certification { Name = "CA(SA)", IssuingBody = "SAICA", Duration = "7 years total", IsRequired = true },
                        new Certification { Name = "CFA Charter", IssuingBody = "CFA Institute", Duration = "2-4 years", IsRequired = false }
                    },
                    EntrySalaryRange = "R350,000 - R500,000",
                    MidCareerSalaryRange = "R700,000 - R1,200,000",
                    SeniorSalaryRange = "R1,500,000 - R3,000,000+",
                    JobOutlook = "Excellent - Always in high demand",
                    TypicalRoles = new() { "Auditor", "Tax Consultant", "Financial Manager", "CFO", "Business Advisor" },
                    InterestingFacts = new()
                    {
                        "CA(SA) is considered one of the most prestigious qualifications globally",
                        "Many CEOs of major companies are qualified CAs",
                        "CAs can work in virtually any industry",
                        "The qualification opens doors to international opportunities"
                    },
                    DailyActivities = new() { "Financial analysis", "Auditing financial statements", "Tax planning", "Business consulting", "Report preparation" },
                    RequiredSkills = new() { "Numerical ability", "Analytical thinking", "Ethics", "Communication", "Business acumen" },
                    WorkEnvironments = new() { "Audit firms (Big 4)", "Banks", "Corporations", "Government", "Private practice" }
                },

                new CareerPath
                {
                    CareerName = "Investment Banker",
                    Description = "Advise companies on financial strategies, mergers, acquisitions, and raising capital through stock and bond offerings.",
                    Field = CareerField.Finance,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Commerce },
                    RequiredSubjects = new() { "Mathematics", "Accounting", "Economics" },
                    MinimumAverageRequired = 75,
                    SubjectMinimums = new() { { "Mathematics", 80 }, { "Accounting", 75 } },
                    MinimumEducation = "BCom Finance/Economics + Honours",
                    RecommendedDegrees = new() { "BCom Finance", "BCom Economics", "MBA", "CFA" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "CFA Charter", IssuingBody = "CFA Institute", Duration = "2-4 years", IsRequired = false },
                        new Certification { Name = "MBA", IssuingBody = "Business Schools", Duration = "1-2 years", IsRequired = false }
                    },
                    EntrySalaryRange = "R400,000 - R650,000",
                    MidCareerSalaryRange = "R900,000 - R1,800,000",
                    SeniorSalaryRange = "R2,000,000 - R5,000,000+",
                    JobOutlook = "Good - Competitive but well-rewarded",
                    TypicalRoles = new() { "Analyst", "Associate", "Vice President", "Director", "Managing Director" },
                    InterestingFacts = new()
                    {
                        "Investment bankers work on billion-rand deals",
                        "The job offers some of the highest starting salaries in any field",
                        "You'll work with CEOs and company boards on major decisions",
                        "Investment bankers helped build some of the world's largest companies"
                    },
                    DailyActivities = new() { "Financial modeling", "Client presentations", "Deal negotiations", "Market research", "Due diligence" },
                    RequiredSkills = new() { "Financial analysis", "Excel mastery", "Presentation skills", "Networking", "Work ethic" },
                    WorkEnvironments = new() { "Investment banks", "Financial institutions", "Corporate offices", "International travel" }
                },

                // LAW
                new CareerPath
                {
                    CareerName = "Lawyer/Attorney",
                    Description = "Represent clients in legal matters, provide legal advice, and advocate for justice in courts of law.",
                    Field = CareerField.Law,
                    RequiredStrengths = new() { SubjectCategory.Languages, SubjectCategory.Humanities },
                    RequiredSubjects = new() { "English", "Any other language" },
                    MinimumAverageRequired = 65,
                    SubjectMinimums = new() { { "English", 70 } },
                    MinimumEducation = "LLB (Bachelor of Laws)",
                    RecommendedDegrees = new() { "LLB (4 years)", "LLM (optional specialization)" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Attorney Admission", IssuingBody = "Legal Practice Council", Duration = "After articles", IsRequired = true },
                        new Certification { Name = "Specialization", IssuingBody = "Various", Duration = "LLM 1-2 years", IsRequired = false }
                    },
                    EntrySalaryRange = "R250,000 - R400,000",
                    MidCareerSalaryRange = "R600,000 - R1,200,000",
                    SeniorSalaryRange = "R1,500,000 - R3,000,000+",
                    JobOutlook = "Good - Legal services always needed",
                    TypicalRoles = new() { "Candidate Attorney", "Attorney", "Advocate", "Senior Counsel", "Judge" },
                    InterestingFacts = new()
                    {
                        "Nelson Mandela was a lawyer before becoming South Africa's first democratic president",
                        "Lawyers helped write South Africa's groundbreaking Constitution",
                        "You can specialize in exciting areas like sports law or entertainment law",
                        "International law allows you to work on global issues"
                    },
                    DailyActivities = new() { "Legal research", "Client consultations", "Court appearances", "Drafting documents", "Negotiations" },
                    RequiredSkills = new() { "Critical thinking", "Research", "Communication", "Argumentation", "Ethics" },
                    WorkEnvironments = new() { "Law firms", "Courts", "Corporate legal departments", "Government", "NGOs" }
                },

                // EDUCATION
                new CareerPath
                {
                    CareerName = "Teacher",
                    Description = "Educate and inspire the next generation by teaching academic subjects and helping students develop critical life skills.",
                    Field = CareerField.Education,
                    RequiredStrengths = new() { SubjectCategory.Languages, SubjectCategory.Humanities },
                    RequiredSubjects = new() { "Any teaching subjects" },
                    MinimumAverageRequired = 60,
                    SubjectMinimums = new() { { "English", 60 } },
                    MinimumEducation = "Bachelor of Education (BEd) or PGCE",
                    RecommendedDegrees = new() { "BEd (4 years)", "BA/BSc + PGCE (1 year)" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "SACE Registration", IssuingBody = "South African Council for Educators", Duration = "After graduation", IsRequired = true }
                    },
                    EntrySalaryRange = "R180,000 - R280,000",
                    MidCareerSalaryRange = "R300,000 - R450,000",
                    SeniorSalaryRange = "R500,000 - R700,000",
                    JobOutlook = "Good - Teachers always needed",
                    TypicalRoles = new() { "Classroom Teacher", "Head of Department", "Deputy Principal", "Principal", "Education Specialist" },
                    InterestingFacts = new()
                    {
                        "One teacher impacts an average of 3,000 students in their career!",
                        "Teachers have school holidays - over 12 weeks per year",
                        "The profession offers job security and fulfillment",
                        "Great teachers are remembered for life by their students"
                    },
                    DailyActivities = new() { "Teaching lessons", "Preparing materials", "Marking assessments", "Parent meetings", "Student mentoring" },
                    RequiredSkills = new() { "Communication", "Patience", "Creativity", "Organization", "Passion for learning" },
                    WorkEnvironments = new() { "Schools", "Colleges", "Private tutoring", "Online education", "Training centers" }
                },

                // TECHNOLOGY
                new CareerPath
                {
                    CareerName = "Data Scientist",
                    Description = "Analyze complex data sets using statistics, machine learning, and programming to help organizations make data-driven decisions.",
                    Field = CareerField.Technology,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Technology },
                    RequiredSubjects = new() { "Mathematics", "Information Technology" },
                    MinimumAverageRequired = 70,
                    SubjectMinimums = new() { { "Mathematics", 75 } },
                    MinimumEducation = "BSc Data Science or Computer Science",
                    RecommendedDegrees = new() { "BSc Data Science", "BSc Computer Science", "Honours in Data Science" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Google Data Analytics Professional", IssuingBody = "Google", Duration = "6 months", IsRequired = false },
                        new Certification { Name = "AWS Machine Learning", IssuingBody = "Amazon", Duration = "3-6 months", IsRequired = false }
                    },
                    EntrySalaryRange = "R350,000 - R550,000",
                    MidCareerSalaryRange = "R700,000 - R1,200,000",
                    SeniorSalaryRange = "R1,300,000 - R2,000,000+",
                    JobOutlook = "Excellent - Fastest growing field in tech",
                    TypicalRoles = new() { "Junior Data Analyst", "Data Scientist", "Machine Learning Engineer", "AI Researcher", "Chief Data Officer" },
                    InterestingFacts = new()
                    {
                        "Data scientists are called 'the sexiest job of the 21st century'",
                        "Netflix saves $1 billion per year using data science for recommendations",
                        "Data science helped decode the human genome",
                        "AI and machine learning are transforming every industry"
                    },
                    DailyActivities = new() { "Analyzing data", "Building predictive models", "Data visualization", "Machine learning implementation", "Presenting insights" },
                    RequiredSkills = new() { "Statistics", "Programming (Python, R)", "Machine learning", "Critical thinking", "Communication" },
                    WorkEnvironments = new() { "Tech companies", "Banks", "Retail", "Healthcare", "Research institutions" }
                },

                // ARTS & DESIGN
                new CareerPath
                {
                    CareerName = "Architect",
                    Description = "Design buildings and spaces that are functional, safe, sustainable, and aesthetically pleasing.",
                    Field = CareerField.Architecture,
                    RequiredStrengths = new() { SubjectCategory.Mathematics, SubjectCategory.Arts },
                    RequiredSubjects = new() { "Mathematics", "Visual Arts" },
                    MinimumAverageRequired = 65,
                    SubjectMinimums = new() { { "Mathematics", 70 }, { "Visual Arts", 65 } },
                    MinimumEducation = "Bachelor of Architecture (BArch)",
                    RecommendedDegrees = new() { "BArch (5 years)", "MArch (optional)" },
                    YearsOfStudy = 5,
                    Certifications = new()
                    {
                        new Certification { Name = "Professional Architect", IssuingBody = "SACAP", Duration = "2 years work experience", IsRequired = true }
                    },
                    EntrySalaryRange = "R250,000 - R400,000",
                    MidCareerSalaryRange = "R500,000 - R800,000",
                    SeniorSalaryRange = "R900,000 - R1,500,000+",
                    JobOutlook = "Good - Urban development drives demand",
                    TypicalRoles = new() { "Graduate Architect", "Project Architect", "Senior Architect", "Principal", "Urban Designer" },
                    InterestingFacts = new()
                    {
                        "Architects design everything from homes to skyscrapers to entire cities",
                        "The profession combines art, science, and technology",
                        "Sustainable architecture is shaping the future of our planet",
                        "Famous architects like Zaha Hadid revolutionized building design"
                    },
                    DailyActivities = new() { "Creating designs", "3D modeling", "Client meetings", "Site visits", "Coordinating with engineers" },
                    RequiredSkills = new() { "Creativity", "Technical drawing", "CAD software", "Spatial awareness", "Project management" },
                    WorkEnvironments = new() { "Architecture firms", "Construction companies", "Private practice", "Government", "Urban planning" }
                },

                // MEDIA & COMMUNICATIONS
                new CareerPath
                {
                    CareerName = "Digital Marketing Specialist",
                    Description = "Create and manage online marketing campaigns using social media, content, SEO, and analytics to grow brands.",
                    Field = CareerField.Media,
                    RequiredStrengths = new() { SubjectCategory.Languages, SubjectCategory.Arts },
                    RequiredSubjects = new() { "English", "Information Technology" },
                    MinimumAverageRequired = 60,
                    SubjectMinimums = new() { { "English", 65 } },
                    MinimumEducation = "BCom Marketing or BA Media Studies",
                    RecommendedDegrees = new() { "BCom Marketing", "BA Media Studies", "Diploma in Digital Marketing" },
                    YearsOfStudy = 3,
                    Certifications = new()
                    {
                        new Certification { Name = "Google Digital Marketing", IssuingBody = "Google", Duration = "3-6 months", IsRequired = false },
                        new Certification { Name = "HubSpot Content Marketing", IssuingBody = "HubSpot", Duration = "2-3 months", IsRequired = false },
                        new Certification { Name = "Facebook Blueprint", IssuingBody = "Meta", Duration = "2-3 months", IsRequired = false }
                    },
                    EntrySalaryRange = "R180,000 - R320,000",
                    MidCareerSalaryRange = "R400,000 - R700,000",
                    SeniorSalaryRange = "R800,000 - R1,200,000+",
                    JobOutlook = "Excellent - Digital transformation drives demand",
                    TypicalRoles = new() { "Social Media Manager", "SEO Specialist", "Content Strategist", "Digital Marketing Manager", "Brand Manager" },
                    InterestingFacts = new()
                    {
                        "Digital marketing budgets now exceed traditional advertising globally",
                        "You can work with international brands from anywhere",
                        "One viral campaign can reach millions in hours",
                        "The field is creative, analytical, and constantly evolving"
                    },
                    DailyActivities = new() { "Creating content", "Managing social media", "Analyzing metrics", "Running ad campaigns", "SEO optimization" },
                    RequiredSkills = new() { "Creativity", "Writing", "Analytics", "Social media savvy", "Adaptability" },
                    WorkEnvironments = new() { "Marketing agencies", "Corporations", "Startups", "Remote work", "Freelance" }
                },

                // SCIENCE
                new CareerPath
                {
                    CareerName = "Environmental Scientist",
                    Description = "Study and develop solutions to environmental problems, protecting ecosystems and promoting sustainability.",
                    Field = CareerField.Science,
                    RequiredStrengths = new() { SubjectCategory.Science },
                    RequiredSubjects = new() { "Life Sciences", "Geography", "Physical Sciences" },
                    MinimumAverageRequired = 65,
                    SubjectMinimums = new() { { "Life Sciences", 70 }, { "Geography", 65 } },
                    MinimumEducation = "BSc Environmental Science",
                    RecommendedDegrees = new() { "BSc Environmental Science", "BSc Conservation Biology", "Honours/MSc" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "SACNASP Registration", IssuingBody = "South African Council for Natural Scientific Professions", Duration = "After graduation", IsRequired = true }
                    },
                    EntrySalaryRange = "R220,000 - R350,000",
                    MidCareerSalaryRange = "R400,000 - R650,000",
                    SeniorSalaryRange = "R700,000 - R1,000,000",
                    JobOutlook = "Very Good - Climate change drives demand",
                    TypicalRoles = new() { "Environmental Consultant", "Conservation Officer", "Research Scientist", "Sustainability Manager", "Policy Advisor" },
                    InterestingFacts = new()
                    {
                        "Environmental scientists are literally saving the planet",
                        "You can work in amazing locations from oceans to rainforests",
                        "The field combines lab work, fieldwork, and policy making",
                        "Your work directly impacts future generations"
                    },
                    DailyActivities = new() { "Field sampling", "Lab analysis", "Environmental assessments", "Report writing", "Conservation planning" },
                    RequiredSkills = new() { "Scientific knowledge", "Research skills", "Problem-solving", "Communication", "Passion for nature" },
                    WorkEnvironments = new() { "Consulting firms", "National parks", "Research institutions", "Government", "NGOs" }
                },

                // HEALTHCARE
                new CareerPath
                {
                    CareerName = "Nurse",
                    Description = "Provide patient care, administer treatments, and support doctors in hospitals and healthcare facilities.",
                    Field = CareerField.Healthcare,
                    RequiredStrengths = new() { SubjectCategory.Science },
                    RequiredSubjects = new() { "Life Sciences", "Mathematics" },
                    MinimumAverageRequired = 60,
                    SubjectMinimums = new() { { "Life Sciences", 65 }, { "Mathematics", 50 } },
                    MinimumEducation = "Bachelor of Nursing (BN) or Diploma in Nursing",
                    RecommendedDegrees = new() { "BN (4 years)", "Diploma in Nursing (3-4 years)" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "Nursing Registration", IssuingBody = "SANC", Duration = "After graduation", IsRequired = true },
                        new Certification { Name = "Specialization", IssuingBody = "SANC", Duration = "1-2 years", IsRequired = false }
                    },
                    EntrySalaryRange = "R180,000 - R280,000",
                    MidCareerSalaryRange = "R320,000 - R500,000",
                    SeniorSalaryRange = "R550,000 - R800,000",
                    JobOutlook = "Excellent - Critical shortage of nurses",
                    TypicalRoles = new() { "Staff Nurse", "Specialized Nurse", "Nurse Manager", "Nurse Educator", "Nurse Practitioner" },
                    InterestingFacts = new()
                    {
                        "Nurses are the backbone of the healthcare system",
                        "Florence Nightingale pioneered modern nursing in the 1800s",
                        "Nurses can specialize in exciting fields like trauma, pediatrics, or surgery",
                        "International nursing opportunities are abundant"
                    },
                    DailyActivities = new() { "Patient care", "Administering medication", "Monitoring vital signs", "Assisting doctors", "Patient education" },
                    RequiredSkills = new() { "Compassion", "Clinical skills", "Communication", "Stamina", "Quick thinking" },
                    WorkEnvironments = new() { "Hospitals", "Clinics", "Schools", "Corporate wellness", "Home healthcare" }
                },

                // AGRICULTURE
                new CareerPath
                {
                    CareerName = "Agricultural Scientist",
                    Description = "Develop innovative farming methods, improve crop yields, and ensure food security through scientific research.",
                    Field = CareerField.Agriculture,
                    RequiredStrengths = new() { SubjectCategory.Science },
                    RequiredSubjects = new() { "Life Sciences", "Agricultural Sciences", "Physical Sciences" },
                    MinimumAverageRequired = 60,
                    SubjectMinimums = new() { { "Life Sciences", 65 }, { "Agricultural Sciences", 65 } },
                    MinimumEducation = "BSc Agriculture",
                    RecommendedDegrees = new() { "BSc Agriculture", "BSc Agronomy", "BSc Animal Science" },
                    YearsOfStudy = 4,
                    Certifications = new()
                    {
                        new Certification { Name = "SACNASP Registration", IssuingBody = "SACNASP", Duration = "After graduation", IsRequired = false }
                    },
                    EntrySalaryRange = "R200,000 - R320,000",
                    MidCareerSalaryRange = "R380,000 - R600,000",
                    SeniorSalaryRange = "R650,000 - R900,000",
                    JobOutlook = "Good - Food security is critical",
                    TypicalRoles = new() { "Farm Manager", "Agricultural Consultant", "Research Scientist", "Agronomist", "Agricultural Economist" },
                    InterestingFacts = new()
                    {
                        "Agriculture feeds the world - 7.9 billion people!",
                        "Modern farming uses drones, AI, and satellite technology",
                        "Agricultural scientists are combating climate change",
                        "South Africa is a major agricultural exporter"
                    },
                    DailyActivities = new() { "Field research", "Crop monitoring", "Soil analysis", "Farm planning", "Technology implementation" },
                    RequiredSkills = new() { "Scientific knowledge", "Problem-solving", "Business acumen", "Technology use", "Practical skills" },
                    WorkEnvironments = new() { "Farms", "Research stations", "Agribusiness", "Government departments", "Consulting" }
                }
            };

            return _careerPaths;
        }

        public static List<string> GetCommonInterests()
        {
            return new List<string>
            {
                "Working with technology and computers",
                "Helping and caring for people",
                "Creating and designing things",
                "Solving complex problems",
                "Working with numbers and data",
                "Writing and communicating",
                "Working outdoors or with nature",
                "Leading and managing teams",
                "Researching and discovering new things",
                "Building and constructing",
                "Teaching and mentoring others",
                "Analyzing and strategizing",
                "Performing or entertaining",
                "Organizing and planning",
                "Working with animals",
                "Sports and physical activities",
                "Art and creative expression",
                "Music and sound",
                "Business and entrepreneurship",
                "Social justice and advocacy"
            };
        }

        public static Dictionary<string, List<string>> GetCommonSubjectsByGrade()
        {
            return new Dictionary<string, List<string>>
            {
                ["Grade 10-12"] = new()
                {
                    "Mathematics", "Mathematical Literacy", "Physical Sciences",
                    "Life Sciences", "Accounting", "Economics", "Business Studies",
                    "Geography", "History", "English", "Afrikaans", "IsiZulu",
                    "Information Technology", "Computer Applications Technology",
                    "Visual Arts", "Design", "Dramatic Arts", "Music",
                    "Consumer Studies", "Hospitality Studies", "Tourism",
                    "Agricultural Sciences", "Agricultural Technology",
                    "Civil Technology", "Electrical Technology", "Mechanical Technology",
                    "Engineering Graphics and Design"
                },
                ["Grade 8-9"] = new()
                {
                    "Mathematics", "Natural Sciences", "Technology",
                    "Social Sciences", "English", "Afrikaans", "IsiZulu",
                    "Economic and Management Sciences", "Life Orientation",
                    "Creative Arts"
                },
                ["Grade 4-7"] = new()
                {
                    "Mathematics", "English", "Home Language",
                    "Natural Sciences and Technology", "Social Sciences",
                    "Life Skills"
                }
            };
        }
    }
}
