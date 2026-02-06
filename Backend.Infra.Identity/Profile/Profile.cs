using Backend.Infra.Base;
using Backend.Infra.Base.Interfaces;
using Backend.Infra.Identity.Interfaces.Profile;
using Base.Infra.Cryptography;
using Newtonsoft.Json;

namespace Backend.Infra.Identity.Profile
{
    public class Profile : BaseNamedStateful, IProfile, IBaseNamedStateful
    {
        private string? _hashAuth { get; set; }
        public string? Email { get; set; }
        public string[]? Role { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public string? HashAuth
        {
            get
            {
                if (string.IsNullOrEmpty(_hashAuth) || string.IsNullOrWhiteSpace(_hashAuth))
                    _hashAuth = HashAuthGen();

                var iVal = HashAuthGen();
                if (iVal != _hashAuth)
                    _hashAuth = HashAuthGen();

                return _hashAuth;
            }
            set
            {
                _hashAuth = value;
            }
        }

        protected virtual string? HashAuthGen()
        {
            if (string.IsNullOrEmpty(this.Email) || string.IsNullOrWhiteSpace(this.Email))
                return string.Empty;

            if (string.IsNullOrEmpty(this.Password) || string.IsNullOrWhiteSpace(this.Password))
                return string.Empty;

            var json = JsonConvert.SerializeObject(new
            {
                Email = this.Email,
                Password = Crypto.DecodeFrom64(this.Password)
            });
            
            var sha512 = Crypto.SHA512(json);
            var base64 = Crypto.EncodeToBase64(sha512.ToUpper());

            return base64;
        }
    }
}
