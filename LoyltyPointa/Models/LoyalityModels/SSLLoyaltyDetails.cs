using LoyltyPointa.Dto.userdetails;

namespace LoyltyPointa.Models.LoyalityModels
{
    public class SSLLoyaltyDetails
    {
        public string barcodeImage { get; set; }
        public string cardDesc { get; set; }
        public string cardValidDate { get; set; }
        public string dateOfLastLinkingAttempt { get; set; }
        public string fccCardImage { get; set; }
        public bool isLinked { get; set; }
        public bool isLocked { get; set; }
        public bool isTermsAccepted { get; set; }
        public string nameOnCard { get; set; }
        public int numberOfChildren { get; set; }
        public bool optionEmail { get; set; }
        public bool optionMail { get; set; }
        public bool optionMobile { get; set; }
        public bool optionTele { get; set; }
        public string original16DigitCardNumber { get; set; }
        public string original16DigitCardNumberFormatted { get; set; }
        public string primaryCardNumber { get; set; }
        public bool selfEmployed { get; set; }
        public string tier { get; set; }

        public SSLLoyaltyDetails() { }

        public SSLLoyaltyDetails(SSLLoyaltyDetails ssldetails)
        {
            barcodeImage = ssldetails.barcodeImage;
            cardDesc = ssldetails.cardDesc;
            cardValidDate = ssldetails.cardValidDate;
            dateOfLastLinkingAttempt = ssldetails.dateOfLastLinkingAttempt;
            fccCardImage = ssldetails.fccCardImage;
            isLinked = ssldetails.isLinked;
            isLocked = ssldetails.isLocked;
            isTermsAccepted = ssldetails.isTermsAccepted;
            nameOnCard = ssldetails.nameOnCard;
            numberOfChildren = ssldetails.numberOfChildren;
            optionEmail = ssldetails.optionEmail;
            optionMail = ssldetails.optionMail;
            optionMobile = ssldetails.optionMobile;
            optionTele = ssldetails.optionTele;
            original16DigitCardNumber = ssldetails.original16DigitCardNumber;
            original16DigitCardNumberFormatted = ssldetails.original16DigitCardNumberFormatted;
            primaryCardNumber = ssldetails.primaryCardNumber;
            selfEmployed = ssldetails.selfEmployed;
            tier = ssldetails.tier;
        }
    }

    }
