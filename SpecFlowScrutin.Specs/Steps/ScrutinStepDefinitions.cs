using ResultatScrutin;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace SpecFlowScrutin.Specs.Steps
{
    [Binding]
    public sealed class ScrutinStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private readonly Scrutin _scrutin = new Scrutin();

        public ScrutinStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("followings votes")]
        public void GivenThisFollowingVotes(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _scrutin.AddVote(row[0]);
            }
        }

        [Given("followings candidates")]
        public void GivenFollowingsCandidates(Table table)
        {
            foreach(TableRow row in table.Rows)
            {
                _scrutin.AddCandidate(row[0]);
            }
        }

        [Given(@"is second round")]
        public void GivenIsSecondRound()
        {
            _scrutin.IsSecondRound = true;
        }



        [When("all peoples votes")]
        public void WhenAllPeoplesVotes()
        {
            _scrutin.FinVote();
        }

        [When(@"counting is finish")]
        public void WhenCountingIsFinish()
        {
            _scrutin.DepouilleVotes();
        }



        [Then("vote is closed")]
        public void ThenVoteIsClosed()
        {
            _scrutin.IsClosed.Should().BeTrue();
        }

        [Then(@"(.*) won")]
        public void ThenCandidateWon(string nom)
        {
            _scrutin.GetVainqueur().Nom.Should().Be(nom);
        }

        [Then(@"show (.*)")]
        public void ThenShowDavidMarc(string p)
        {
            _scrutin.ShowResult().Should().Be(p);
        }

        [Then(@"second round with (.*) and (.*)")]
        public void ThenSecondRoundWith(string c1, string c2)
        {
            _scrutin.CreateSecondRound(c1, c2);
            _scrutin.IsSecondRound.Should().BeTrue();
        }

        [Then(@"egality")]
        public void ThenEgality()
        {
            _scrutin.GetVainqueur().Should().Be(null);
        }

    }
}
