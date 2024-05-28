namespace EngrafoCA.Application.UnitTests.Documentations.Commands.TestUtils
{
  public class GetDocumentationQueryTestUtils
  {
    public static GetDocumentationQuery CreateQuery(Guid id)
    {
      return GetDocumentationQuery{
        Id = id;
      };
    }
  }
}
