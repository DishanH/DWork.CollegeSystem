using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sample.IntegrationTests
{
    using static Testing;
    public class TestBase
    {
        [SetUp]
        public async Task SetUp() {
            await ResetState();
        }
    }

}
