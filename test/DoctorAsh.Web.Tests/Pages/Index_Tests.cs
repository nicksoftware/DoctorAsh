using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DoctorAsh.Pages
{
    public class Index_Tests : DoctorAshWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
