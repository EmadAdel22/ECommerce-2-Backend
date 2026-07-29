using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Dtos
{
    public record CategoryDTo
        (string Name,string Description);

    public record CategoryUpdateDto
        (string Name,string Description, int Id);
}
