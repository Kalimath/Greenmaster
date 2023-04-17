using eu.greenmaster.Models.Helpers;

namespace eu.greenmaster.Examples{
public static class Base64Examples
  {
      public static readonly string ImageSpecie = FileConverter.ToBase64(PathExamples.PathImageSpecie);
      public static readonly string ImageRendering = FileConverter.ToBase64(PathExamples.PathImageRendering);
  }
 }