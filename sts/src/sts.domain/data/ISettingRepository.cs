using sts.domain.model.settings;
using tuc.core.domain.data;

namespace sts.domain.data
{
  internal interface ISettingRepository
      : IRepository<SettingRoot, SettingRoot, string>
  {

  }
}