namespace BrightSky.SharedKernel.Tests;

public class OptionAndOneOfModellingContactInfo
{
    public record String50(string Value);
    public record Fullname(String50 Firstname, String50 Lastname);
    
    public record EmailAddress(string Email);

    public record OutwardCode(string code);
    public record InwardCode(string code);
    public record UkPostCode(OutwardCode outward, InwardCode inward);
    public record UkPostalAddress(
        string HouseNumberAndStreet, 
        Option<string> Locality,            // Locality is optional 
        string TownOrCity, 
        UkPostCode PostCode);
    
    public record LandlineNumber(string Number);
    public record MobileNumber(string Number);
    
    // PhoneNumber can be a mobile or a landline number
    public record PhoneNumber : OneOf<MobileNumber, LandlineNumber>
    {
        public new static PhoneNumber Case(MobileNumber value) => new(value);
        public new static PhoneNumber Case(LandlineNumber value) => new(value);
        
        public static implicit operator PhoneNumber(MobileNumber value) => new(value);
        public static implicit operator PhoneNumber(LandlineNumber value) => new(value);
        
        public static implicit operator MobileNumber(PhoneNumber value) => value.Get<MobileNumber>();
        public static implicit operator LandlineNumber(PhoneNumber value) => value.Get<LandlineNumber>();
        
        protected PhoneNumber(MobileNumber value) : base(value)
        {
        }

        protected PhoneNumber(LandlineNumber value) : base(value)
        {
        }
    }
    
    public record ContactInfo(
        EmailAddress Email, 
        UkPostalAddress Address, 
        PhoneNumber PhoneNumber);
    
    // Requirement: A contact must have at least one way of being contacted
    public record Contact(
        Fullname Name, 
        ContactInfo PrimaryContact,             // This is the primary contact info and is required
        Option<ContactInfo> SecondaryContact);  // This is the secondary contact info and is optional
    
}