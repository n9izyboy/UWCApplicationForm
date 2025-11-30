using Microsoft.JSInterop;
using System.Text.Json;
using UWCApplicationForm.Models;

namespace UWCApplicationForm.Services;

/// <summary>
/// Service for managing application form state with localStorage persistence
/// </summary>
public class FormStateService
{
    private readonly IJSRuntime _jsRuntime;
    private const string StorageKey = "uwc_application_form_state";
    private const string LastSavedKey = "uwc_application_form_last_saved";

    public ApplicationFormModel CurrentFormData { get; private set; } = new();
    public int CurrentSection { get; set; } = 0;
    public DateTime? LastSaved { get; private set; }
    public bool HasUnsavedChanges { get; set; } = false;

    // Events
    public event Action? OnStateChanged;
    public event Action<string>? OnSaveCompleted;
    public event Action<string>? OnLoadCompleted;

    public FormStateService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Load form state from localStorage
    /// </summary>
    public async Task<bool> LoadStateAsync()
    {
        try
        {
            var jsonData = await _jsRuntime.InvokeAsync<string?>("LocalStorageHelper.load", StorageKey);
            
            if (!string.IsNullOrEmpty(jsonData))
            {
                CurrentFormData = JsonSerializer.Deserialize<ApplicationFormModel>(jsonData) ?? new();
                
                var lastSavedStr = await _jsRuntime.InvokeAsync<string?>("LocalStorageHelper.load", LastSavedKey);
                if (!string.IsNullOrEmpty(lastSavedStr) && DateTime.TryParse(lastSavedStr, out var lastSavedDate))
                {
                    LastSaved = lastSavedDate;
                }

                HasUnsavedChanges = false;
                NotifyStateChanged();
                OnLoadCompleted?.Invoke("Form data loaded successfully");
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading form state: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Save form state to localStorage
    /// </summary>
    public async Task<bool> SaveStateAsync()
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(CurrentFormData);
            var saved = await _jsRuntime.InvokeAsync<bool>("LocalStorageHelper.save", StorageKey, jsonData);

            if (saved)
            {
                LastSaved = DateTime.Now;
                await _jsRuntime.InvokeAsync<bool>("LocalStorageHelper.save", LastSavedKey, LastSaved.ToString());
                HasUnsavedChanges = false;
                NotifyStateChanged();
                OnSaveCompleted?.Invoke("Form saved successfully");
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving form state: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Clear form state from localStorage
    /// </summary>
    public async Task<bool> ClearStateAsync()
    {
        try
        {
            await _jsRuntime.InvokeAsync<bool>("LocalStorageHelper.remove", StorageKey);
            await _jsRuntime.InvokeAsync<bool>("LocalStorageHelper.remove", LastSavedKey);
            
            CurrentFormData = new();
            CurrentSection = 0;
            LastSaved = null;
            HasUnsavedChanges = false;
            
            NotifyStateChanged();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing form state: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Update form data and mark as having unsaved changes
    /// </summary>
    public void UpdateFormData(Action<ApplicationFormModel> updateAction)
    {
        updateAction(CurrentFormData);
        HasUnsavedChanges = true;
        NotifyStateChanged();
    }

    /// <summary>
    /// Navigate to a specific section
    /// </summary>
    public void NavigateToSection(int sectionIndex)
    {
        if (sectionIndex >= 0 && sectionIndex < 10)
        {
            CurrentSection = sectionIndex;
            NotifyStateChanged();
        }
    }

    /// <summary>
    /// Navigate to next section
    /// </summary>
    public bool NavigateNext()
    {
        if (CurrentSection < 9)
        {
            CurrentSection++;
            NotifyStateChanged();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Navigate to previous section
    /// </summary>
    public bool NavigatePrevious()
    {
        if (CurrentSection > 0)
        {
            CurrentSection--;
            NotifyStateChanged();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get completion percentage
    /// </summary>
    public int GetCompletionPercentage()
    {
        int completedFields = 0;
        int totalFields = 0;

        var properties = typeof(ApplicationFormModel).GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), false).Any());

        totalFields = properties.Count();

        foreach (var property in properties)
        {
            var value = property.GetValue(CurrentFormData);
            
            if (value != null)
            {
                if (value is string strValue && !string.IsNullOrWhiteSpace(strValue))
                {
                    completedFields++;
                }
                else if (value is bool boolValue && boolValue)
                {
                    completedFields++;
                }
                else if (value is DateTime dateValue && dateValue != default)
                {
                    completedFields++;
                }
                else if (value is int intValue && intValue != 0)
                {
                    completedFields++;
                }
            }
        }

        return totalFields > 0 ? (int)((double)completedFields / totalFields * 100) : 0;
    }

    /// <summary>
    /// Get section names
    /// </summary>
    public static string[] GetSectionNames()
    {
        return new[]
        {
            "Application Details",
            "Academic Background",
            "Contact Information",
            "Study Preferences",
            "Documents Upload",
            "Previous Studies",
            "Financial Information",
            "Emergency Contact",
            "Additional Information",
            "Review & Submit"
        };
    }

    /// <summary>
    /// Check if section is completed
    /// </summary>
    public bool IsSectionCompleted(int sectionIndex)
    {
        // Basic validation - can be enhanced per section
        return sectionIndex < CurrentSection;
    }

    /// <summary>
    /// Notify state change to subscribers
    /// </summary>
    private void NotifyStateChanged()
    {
        OnStateChanged?.Invoke();
    }
}
