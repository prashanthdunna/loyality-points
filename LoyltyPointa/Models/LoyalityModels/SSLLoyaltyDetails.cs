namespace LoyltyPointa.Models.LoyalityModels
{
    public class SSLLoyaltyDetails
    {
        public string BarcodeImage { get; set; }

        public string CardDesc { get; set; }

        public string CardValidDate { get; set; }

        public string DateOfLastLinkingAttempt { get; set; }

        public string FccCardImage { get; set; }

        public bool IsLinked { get; set; }

        public bool IsLocked { get; set; }

        public bool IsTermsAccepted { get; set; }

        public string NameOnCard { get; set; }

        public int NumberOfChildren { get; set; }

        public bool OptionEmail { get; set; }

        public bool OptionMail { get; set; }

        public bool OptionMobile { get; set; }

        public bool OptionTele { get; set; }

        public string Original16DigitCardNumber { get; set; }

        public string Original16DigitCardNumberFormatted { get; set; }

        public string PrimaryCardNumber { get; set; }

        public bool SelfEmployed { get; set; }

        public string Tier { get; set; }
    }
}
