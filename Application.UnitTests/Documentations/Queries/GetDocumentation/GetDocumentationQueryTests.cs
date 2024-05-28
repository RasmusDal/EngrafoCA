namespace Application.UnitTests.Documentations.Queries.GetDocumentation
{
	public class GetDocumentationQueryTests
	{
		private readonly GetDocumentationQueryHandler _handler;
		private readonly Mock<IApplicationDbContext> _dbContextMock;
		private readonly Mock<DbSet<Documentation>> _documentationDbSetMock;

		public GetDocumentationQueryTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _handler = new CreateDocumentationCommandHandler(_dbContextMock.Object);
			_documentationDbSetMock = new Mock<DbSet<Documentation>>();

			_dbContextMock.Setup(db => db.Documentations).Returns(_documentationDbSetMock.Object);
        }
		public async Task HandleGetDocumentationQuery_WhenIdIsValid_ShouldRetriveDocumentation(GetDocumentationQuery getDocumentationQuery)
		{
			Documentation capturedDocumentation = null;
			_documentationDbSetMock.Setup(db => db.AddAsync(It.IsAny<Documentation>(), It.IsAny<CancellationToken>()))
			.Callback<Documentation, CancellationToken>((doc, _) => capturedDocumentation = doc)
			.Returns(new ValueTask<EntityEntry<Documentation>>());

			_dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
				.ReturnsAsync(1);
		}
	}	
}
