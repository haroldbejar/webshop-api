using Domain.Models;

namespace Domain.Builder
{
    public class UserBuilder : BaseBuilder<User>
    {
        public UserBuilder WithId(int id) { _entity.Id = id; return this; }
        public UserBuilder WithUserName(string userName) { _entity.UserName = userName; return this; }
        public UserBuilder WithPasswordHash(byte[] passwordHash) { _entity.PasswordHash = passwordHash; return this; }
        public UserBuilder WithPasswordSalt(byte[] passwordSalt) {  _entity.PasswordSalt = passwordSalt; return this; }
    }
}
