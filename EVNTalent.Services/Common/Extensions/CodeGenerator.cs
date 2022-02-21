
namespace EVNTalent.Services.Common.Extensions
{
using System;
  public static  class CodeGenerator
    {

        public static string GenerateCandidateCode(int count, int departmentCode, DateTime birthDate)
        {
            string[] s = birthDate.GetDateTimeFormats()[2].Split("/");
            return (1 + count).ToString().PadLeft(3, '0')
              + departmentCode
              + s[1].PadLeft(2, '0') + s[0].PadLeft(2, '0') + s[2].PadLeft(2, '0');
        }
    }
}
