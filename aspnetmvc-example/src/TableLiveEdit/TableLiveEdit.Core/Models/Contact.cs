namespace TableLiveEdit.Core.Models
{
    partial class Contact
    {
        public void Update(Contact contact)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            EmailAddress = contact.EmailAddress;
        }
    }
}
