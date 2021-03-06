using Paramore.Domain.Documents;
using Paramore.Domain.ValueTypes;
using Paramore.Infrastructure.Repositories;
using Version = Paramore.Infrastructure.Repositories.Version;

namespace Paramore.Domain.Entities.Speakers
{
    public class Speaker : AggregateRoot<SpeakerDocument>
    {
        private SpeakerBio bio;
        private EmailAddress emailAddress;
        private Name name;
        private PhoneNumber phoneNumber;

        public Speaker(Id id, Version version, SpeakerBio bio, PhoneNumber phoneNumber, EmailAddress emailAddress, Name name) : base(id, version)
        {
            this.bio = bio;
            this.emailAddress = emailAddress;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public Speaker() : base(new Id(), new Version()){}

        #region Aggregate Persistence
        public override void Load(SpeakerDocument document)
        {
            bio = new SpeakerBio(document.Bio);
            emailAddress = new EmailAddress(document.Email);
            name = new Name(document.Name);
            phoneNumber = new PhoneNumber(document.PhoneNumber);
        }

        protected override SpeakerDocument ToDocument()
        {
            return new SpeakerDocument(Id, Version, bio, phoneNumber, emailAddress, name);
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Bio: {0}, EmailAddress: {1}, Name: {2}, PhoneNumber: {3}", bio, emailAddress, name, phoneNumber);
        }
    }
}