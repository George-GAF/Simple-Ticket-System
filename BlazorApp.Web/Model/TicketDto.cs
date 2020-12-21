using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TicketDto
{
    [MaxLength(50)]
    public string TicketNo { get; set; }
    public DateTime TicketDate { get; set; }
    public int TicketTypeId { get; set; }        
    public string TicketTypeName { get; set; } 
    [MaxLength(100)]
    public string Subject { get; set; }      
    public string Description { get; set; }   
    public DateTime OpenOn { get; set; }       
    public int OpenByUserId { get; set; }
    public string OpenByUserName { get; set; } 
    public DateTime? ClosedOn { get; set; }    
    public bool Closed { get; set; } = false;     
    public int CloseByUserId { get; set; }
    public string CloseByUserName { get; set; }         
    public int CustomerId { get; set; }                
    public int AssetId { get; set; }
    public Priority Priority { get; set; }    
    public string CustomerName { get; set; } 
    public string AssetName { get; set; }    
    public int DeviceId { get; set; }
    public string DeviceName { get; set; } 
    public bool IsSelected { get; set; } 
    public List<TicketDetailDto> TicketDetails { get; set; }
}


public class TicketDetailDto
{
    public string TicketNo { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedByUserId { get; set; }
    public string CreatedUserName { get; set; }
    [MaxLength(200)]
    public string DetailDescription { get; set; }
    public int AssignToTechnicianId { get; set; }  
    public string TechnicianName { get; set; }
    public byte[] Attachment { get; set; } 
    public DateTime? StartOn { get; set; }
    public DateTime? EndOn { get; set; }
    // If False Customer Can't Show This Detail
    public bool IsInternal { get; set; } = false;
}

public enum Priority
{
    Lowest = 0,
    Low = 1,
    Normal = 2,
    High = 3,
    Critical = 4
}
public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public bool IsEmplo { get; set; }
}