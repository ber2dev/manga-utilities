using System;

namespace Mse.Core.Utils
{
   public class ParameterValidations
   {
      public static void AssertNull<T>(T pItem, string pParameterName = "pItem")
         where T : class
      {
         if (ReferenceEquals(pItem, null))
         {
            throw new ArgumentNullException(pParameterName);
         }
      }
   }
}
