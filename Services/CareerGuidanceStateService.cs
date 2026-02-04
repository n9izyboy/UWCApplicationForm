using System;
using UWCApplicationForm.Models;

namespace UWCApplicationForm.Services
{
    public class CareerGuidanceStateService
    {
        public StudentAcademicProfile? CurrentProfile { get; set; }
        public CareerRecommendation? CurrentRecommendation { get; set; }
        
        public event Action? OnStateChanged;

        public void SetProfile(StudentAcademicProfile profile)
        {
            CurrentProfile = profile;
            NotifyStateChanged();
        }

        public void SetRecommendation(CareerRecommendation recommendation)
        {
            CurrentRecommendation = recommendation;
            NotifyStateChanged();
        }

        public void Clear()
        {
            CurrentProfile = null;
            CurrentRecommendation = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}
