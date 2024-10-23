using System;
using System.ComponentModel.DataAnnotations;

public class Container
{
    public int ContainerId { get; set; }
    [Required]
    public string ContainerNumber { get; set; }
    [Required]
    public DateTime ShipmentDate { get; set; }
    [Required]
    public string OriginPort { get; set; }
    [Required]
    public string DestinationPort { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string FilePath { get; set; }
}
