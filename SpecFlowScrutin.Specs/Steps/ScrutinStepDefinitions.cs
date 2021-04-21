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
            _scrutin.Vainqueur.Nom = nom;
        }

        [Then(@"show (.*)")]
        public void ThenShowDavidMarc(string p)
        {
            _scrutin.ShowResult().Should().Be(p);
        }


    }
}
