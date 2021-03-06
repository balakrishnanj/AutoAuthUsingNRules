﻿using Newtonsoft.Json;

namespace RuleApiApplication.Messages
{
    public class DecisionRuleResponse
    {
        public int ReviewId { get; set; }
        public int RuleId { get; set; }
        public int DecisionTypeId { get; set; }
        public int ApprovalReasonId { get; set; }
        public int? ApprovedPayLevelId { get; set; }
        public string ApprovalRationale { get; set; }
    }
}