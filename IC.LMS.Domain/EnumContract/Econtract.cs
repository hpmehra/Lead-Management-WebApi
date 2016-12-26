namespace IC.LMS.Domain.EnumContract
{
    public enum Status
    {
     IsLead=1,
     IsProcess=2,
     IsWorking=3
    }

    public enum Gender {
        Male=1,
        Female=2
    }

    public enum ProjectStatus {
        New=1,
        InProgress=1,
        Complete=2,
        Onhold=3
    }
    public enum Priority
    {
        Veryhigh = 1,
        High = 2,
        Medium =3,
        Low = 4
    }
    public enum Stage
    {
        ToContact = 1,
        Prospect = 2,
        Opportunity = 3,
        Proposal = 4,
        Closure=5,
        Dead=6
    }
    public enum DocumentTypeId
    {
        Project = 1,
        Company = 2        
    }
    class Econtract
    {
    }
}
