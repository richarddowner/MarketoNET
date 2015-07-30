using System;
using System.Collections.Generic;

namespace MarketoNet.Response
{
    public class GetCampaignResponse
    {
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public List<CampaignResponse> Result { get; set; } 
    }

    public class CampaignResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
    }
}