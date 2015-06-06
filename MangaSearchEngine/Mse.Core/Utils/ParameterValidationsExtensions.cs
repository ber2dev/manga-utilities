namespace Mse.Core.Utils
{
   public static class ParameterValidationsExtensions
   {
      public static void AssertNull<T>(this T pThis, string pParameterName = "pThis")
         where T : class
      {
         ParameterValidations.AssertNull(pThis, pParameterName);
      }
   }
}
