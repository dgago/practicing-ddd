using System.Collections.Generic;
using tuc.core.domain.model;
using System.Linq;
using tuc.core.domain.extensions;

namespace tuc.core.domain.services.access_control
{
  // TODO: don't like this to be static
  // TODO: should be a singleton, yes, but not static
  public class AccessControlDomainService : DomainService
  {

    #region Private Fields

    // TODO: restrict access to this rules
    public static Dictionary<string, AccessControlRule> _rules;

    #endregion Private Fields

    #region Public Methods

    public static bool HasAccess<K>(string resource, string username, string[] roles, AggregateRoot<K> item)
      where K : class
    {
      AccessControlRule rule = _rules[resource];

      return HasAccess(rule, username, roles, item);
    }

    #endregion Public Methods

    #region Private Methods

    private static bool AcceptsOwner(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.Owner) != 0;
    }

    private static bool AcceptsRoleList(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.Role) != 0;
    }

    private static bool AcceptsSharedList(AccessControlRule rule)
    {
      return (rule.Type & AccessControlType.SharedList) != 0;
    }

    private static bool HasAccess<K>(
      AccessControlRule rule, 
      string username, 
      string[] roles, 
      AggregateRoot<K> item)
      where K : class
    {
      // rule is null
      if (rule == null)
      {
        return false;
      }

      // rule is for users and username is not present
      if (username.IsNows())
      {
        return false;
      }

      // rule accepts roles
      if (AcceptsRoleList(rule) && HasRole(rule, roles))
      {
        return true;
      }

      // rule accepts owner
      if (AcceptsOwner(rule) && IsOwner(username, item))
      {
        return true;
      }

      // rule accepts shared list
      if (AcceptsSharedList(rule) && IsInSharedList(username, item))
      {
        return true;
      }

      return false;
    }

    private static bool HasRole(AccessControlRule rule, string[] roles)
    {
      return rule.Roles.Any(x => roles.Contains(x));
    }

    private static bool IsInSharedList<K>(string username, AggregateRoot<K> item) where K : class
    {
      return item.SharedList.Contains(username);
    }

    private static bool IsOwner<K>(string username, AggregateRoot<K> item) where K : class
    {
      return username == item.Owner;
    }

    #endregion Private Methods

  }
}
