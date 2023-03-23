using Greenmaster_ASP.Helpers;

namespace Greenmaster_ASP.Models.Examples{
public static class Base64Examples
  {
      public static string ImageSpecie = FileConverter.ToBase64(PathExamples.PathImageSpecie);
      public static string ImageRendering = FileConverter.ToBase64(PathExamples.PathImageRendering);
  }
 }