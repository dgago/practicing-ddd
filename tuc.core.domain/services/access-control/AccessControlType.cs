using System;

namespace tuc.core.domain.services.access_control
{
  [Flags]
  public enum AccessControlType
  {
    Role = 1,
    Owner = 2,
    SharedList = 4,
    RoleOwner = Role | Owner,
    RoleSharedList = Role | SharedList,
    OwnerSharedList = Owner | SharedList,
    RoleOwnerSharedList = Role | Owner | SharedList,
  }
}
