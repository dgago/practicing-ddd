namespace tuc.core.domain.application
{
    public abstract class Command
    {

        #region Public Properties

        public virtual string ResourceName
        {
            get
            {
                return GetType().AssemblyQualifiedName;
            }
        }

        public string Username { get; set; }

        public string[] UserRoles { get; set; }

        #endregion Public Properties
    }
}