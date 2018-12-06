using AutoBogus;
using Bogus;
using Heroku.NET.Apps;

namespace Heroku.NET.Tests.Apps
{
    internal static class MockApp
    {
        private static Faker<App> _faker;

        static MockApp()
        {
            _faker = new AutoFaker<App>()
                .RuleFor(a => a.GitUrl, f => f.Internet.Url())
                .RuleFor(a => a.CreatedAt, f => f.Date.Past())
                .RuleFor(a => a.ArchivedAt, () => null);

            _faker.RuleSet("archived", rules =>
            {
                rules.RuleFor(a => a.ArchivedAt, f => f.Date.Recent());
            });
        }

        internal static App Create(string ruleset = null)
        {
            return _faker.Generate(ruleset);
        }
    }
}
