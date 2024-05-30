using Application.Features.Documentations.Queries.GetDocumentation;

namespace EngrafoCA.Application.UnitTests.Documentations.Commands.TestUtils
{
  public class GetDocumentationQueryTestUtils
  {
    public static GetDocumentationQuery CreateQuery(Guid id)
    {
      return new GetDocumentationQuery{
        Id = id
      };
    }
  }
}
