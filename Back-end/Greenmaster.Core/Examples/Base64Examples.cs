using Greenmaster.Core.Helpers;

namespace Greenmaster.Core.Examples{
public static class Base64Examples
  {
      public static string ImageSpecie = FileConverter.ToBase64(PathExamples.PathImageSpecie);
      public static string ImageRendering = FileConverter.ToBase64(PathExamples.PathImageRendering);
  }
 }