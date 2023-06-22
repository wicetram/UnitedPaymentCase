using System.ComponentModel;
using System.Xml.Serialization;

namespace UnitedPaymentCaseEntity.Dto.KPS
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false, ElementName = "Envelope")]
    public partial class KPSRequestDto
    {
        private object headerField;

        private EnvelopeBody bodyField;
        public object Header
        {
            get
            {
                return headerField;
            }
            set
            {
                headerField = value;
            }
        }

        public EnvelopeBody Body
        {
            get
            {
                return bodyField;
            }
            set
            {
                bodyField = value;
            }
        }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private TCKimlikNoDogrula tCKimlikNoDogrulaField;

        [XmlElement(Namespace = "http://tckimlik.nvi.gov.tr/WS")]
        public TCKimlikNoDogrula TCKimlikNoDogrula
        {
            get
            {
                return tCKimlikNoDogrulaField;
            }
            set
            {
                tCKimlikNoDogrulaField = value;
            }
        }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://tckimlik.nvi.gov.tr/WS")]
    [XmlRoot(Namespace = "http://tckimlik.nvi.gov.tr/WS", IsNullable = false)]
    public partial class TCKimlikNoDogrula
    {

        private string tCKimlikNoField;

        private string adField;

        private string soyadField;

        private string dogumYiliField;

        public string TCKimlikNo
        {
            get
            {
                return tCKimlikNoField;
            }
            set
            {
                tCKimlikNoField = value;
            }
        }

        public string Ad
        {
            get
            {
                return adField;
            }
            set
            {
                adField = value;
            }
        }

        public string Soyad
        {
            get
            {
                return soyadField;
            }
            set
            {
                soyadField = value;
            }
        }

        public string DogumYili
        {
            get
            {
                return dogumYiliField;
            }
            set
            {
                dogumYiliField = value;
            }
        }
    }
}
