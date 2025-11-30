using System.ComponentModel.DataAnnotations;

namespace UWCApplicationForm.Models;

/// <summary>
/// Application form data model with validation attributes
/// </summary>
public class ApplicationFormModel
{
    // Section 1: Application Details (Personal Info)
    [Required(ErrorMessage = "Application type is required")]
    public string ApplicationType { get; set; } = string.Empty; // Undergraduate / Postgraduate

    [Required(ErrorMessage = "Identification type is required")]
    public string IdentificationType { get; set; } = string.Empty; // SA ID / Foreign Passport

    [Required(ErrorMessage = "ID/Passport number is required")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "ID/Passport number must be between 6 and 20 characters")]
    public string IdentificationNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 100 characters")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(100)]
    public string MiddleName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please indicate if you've studied at UWC before")]
    public bool HasStudiedAtUWCBefore { get; set; } = false;

    [StringLength(20)]
    public string? PreviousStudentNumber { get; set; }

    // Section 2: Academic Background
    [Required(ErrorMessage = "Highest qualification is required")]
    public string HighestQualification { get; set; } = string.Empty;

    [StringLength(200)]
    public string SchoolName { get; set; } = string.Empty;

    [Range(1900, 2100, ErrorMessage = "Please enter a valid year")]
    public int? YearCompleted { get; set; }

    [Range(0, 100, ErrorMessage = "Average must be between 0 and 100")]
    public decimal? AveragePercentage { get; set; }

    // Section 3: Contact Information
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm email address")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [Compare("Email", ErrorMessage = "Email addresses do not match")]
    public string ConfirmEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 digits")]
    public string PhoneNumber { get; set; } = string.Empty;

    [StringLength(15, MinimumLength = 10, ErrorMessage = "Alternative phone must be between 10 and 15 digits")]
    public string? AlternativePhone { get; set; }

    [Required(ErrorMessage = "Street address is required")]
    [StringLength(200)]
    public string StreetAddress { get; set; } = string.Empty;

    [StringLength(200)]
    public string AddressLine2 { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required")]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Province is required")]
    public string Province { get; set; } = string.Empty;

    [Required(ErrorMessage = "Postal code is required")]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "Postal code must be between 4 and 10 characters")]
    public string PostalCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; } = string.Empty;

    // Section 4: Study Preferences
    [Required(ErrorMessage = "First choice program is required")]
    public string FirstChoiceProgram { get; set; } = string.Empty;

    public string? SecondChoiceProgram { get; set; }

    public string? ThirdChoiceProgram { get; set; }

    [Required(ErrorMessage = "Study mode is required")]
    public string StudyMode { get; set; } = string.Empty; // Full-time / Part-time

    [Required(ErrorMessage = "Intended start year is required")]
    [Range(2024, 2030, ErrorMessage = "Please select a valid year")]
    public int IntendedStartYear { get; set; } = DateTime.Now.Year;

    // Section 5: Documents Upload
    public List<UploadedDocument> UploadedDocuments { get; set; } = new();

    // Section 6: Previous Studies
    public List<PreviousStudy> PreviousStudies { get; set; } = new();

    // Section 7: Financial Information
    [Required(ErrorMessage = "Please indicate funding option")]
    public string FundingOption { get; set; } = string.Empty;

    public bool ApplyingForNSFAS { get; set; } = false;

    public bool ApplyingForBursary { get; set; } = false;

    [StringLength(500)]
    public string? BursaryDetails { get; set; }

    // Section 8: Emergency Contact
    [Required(ErrorMessage = "Emergency contact name is required")]
    [StringLength(200)]
    public string EmergencyContactName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Relationship is required")]
    [StringLength(50)]
    public string EmergencyContactRelationship { get; set; } = string.Empty;

    [Required(ErrorMessage = "Emergency contact phone is required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [StringLength(15)]
    public string EmergencyContactPhone { get; set; } = string.Empty;

    [StringLength(200)]
    public string? EmergencyContactAddress { get; set; }

    // Section 9: Additional Information
    public bool HasDisability { get; set; } = false;

    [StringLength(500)]
    public string? DisabilityDetails { get; set; }

    public bool RequiresAccommodation { get; set; } = false;

    [StringLength(1000)]
    public string? AccommodationDetails { get; set; }

    [StringLength(2000)]
    public string? AdditionalNotes { get; set; }

    // Section 10: Review & Submit
    [Required(ErrorMessage = "You must agree to the terms and conditions")]
    public bool AgreeToTerms { get; set; } = false;

    [Required(ErrorMessage = "You must confirm the information is accurate")]
    public bool ConfirmAccuracy { get; set; } = false;

    public DateTime? SubmittedDate { get; set; }
}

/// <summary>
/// Uploaded document information
/// </summary>
public class UploadedDocument
{
    public string FileName { get; set; } = string.Empty;
    public string DocumentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public DateTime UploadedDate { get; set; } = DateTime.Now;
    public string Base64Content { get; set; } = string.Empty;
}

/// <summary>
/// Previous study information
/// </summary>
public class PreviousStudy
{
    [Required(ErrorMessage = "Institution name is required")]
    [StringLength(200)]
    public string InstitutionName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Qualification is required")]
    [StringLength(200)]
    public string Qualification { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start year is required")]
    [Range(1900, 2100)]
    public int StartYear { get; set; }

    [Range(1900, 2100)]
    public int? EndYear { get; set; }

    public bool Completed { get; set; } = false;

    [StringLength(500)]
    public string? Notes { get; set; }
}
