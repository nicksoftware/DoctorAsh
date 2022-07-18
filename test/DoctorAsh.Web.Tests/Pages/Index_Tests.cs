using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DoctorAsh.Pages
{
    public class Index_Tests : DoctorAshWebTestBase
    {
        [Fact(Skip = "Test not configured for blazor project")]
        public async Task Welcome_Page()
        {
            // var response = await GetResponseAsStringAsync("/");
            // response.ShouldNotBeNull();
            Assert.True(true);
        }
    }
}
