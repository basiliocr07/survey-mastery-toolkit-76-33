
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Web.Models
{
    public class SurveyViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Responses { get; set; }
        public int CompletionRate { get; set; }
        public string Status { get; set; } = "active"; // Can be "active", "draft", or "archived"
    }

    public class QuestionViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Question title is required")]
        public string Title { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; } = true;
        public string Description { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public QuestionSettingsViewModel Settings { get; set; } = new QuestionSettingsViewModel();
    }

    public class QuestionSettingsViewModel
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
    }

    public class DeliveryConfigViewModel
    {
        public string Type { get; set; } = "manual"; // Can be "manual", "scheduled", or "triggered"
        public List<string> EmailAddresses { get; set; } = new List<string>();
        public ScheduleSettingsViewModel Schedule { get; set; } = new ScheduleSettingsViewModel();
        public TriggerSettingsViewModel Trigger { get; set; } = new TriggerSettingsViewModel();
    }

    public class ScheduleSettingsViewModel
    {
        public string Frequency { get; set; } = "monthly"; // Can be "daily", "weekly", "monthly"
        public int DayOfMonth { get; set; } = 1;
        public string Time { get; set; } = "09:00";
    }

    public class TriggerSettingsViewModel
    {
        public string Type { get; set; } = "ticket-closed";
        public int DelayHours { get; set; } = 24;
        public bool SendAutomatically { get; set; } = false;
    }

    // Additional view models for consistency
    public class SurveyQuestionViewModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public bool Required { get; set; } = true;
        public QuestionSettingsViewModel Settings { get; set; } = new QuestionSettingsViewModel();
    }

    public class SurveyDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SurveyQuestionViewModel> Questions { get; set; } = new List<SurveyQuestionViewModel>();
    }

    public class QuestionResponseViewModel
    {
        public string QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionType { get; set; }
        public string Value { get; set; }
        public bool IsValid { get; set; }
    }

    public class SurveySubmissionViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        public string Company { get; set; }
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();
    }
}
