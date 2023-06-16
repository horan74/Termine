findHolidays();

function onChange(cb)
{
    let row = cb.parentNode.parentNode;
    let inputs = row.querySelectorAll("input[type='time']");
    if (cb.checked)
    {
        inputs[0].disabled = true;
        inputs[1].disabled = true;
    }
    else
    {
        inputs[0].disabled = false;
        inputs[1].disabled = false;
    }
}

function findHolidays()
{
    var table = document.getElementById("table");
    console.log(table.rows.length);
    for(var i = 1; i < table.rows.length - 1; i++)
    {
        var timeInputs = table.rows[i].querySelectorAll("input[type='time']");
        if (timeInputs[0].getAttribute("value") == "00:00:00" && timeInputs[1].getAttribute("value") == "00:00:00")
        {
            table.rows[i].querySelector("input[type='checkbox']").checked = true;
            timeInputs[0].disabled = true;
            timeInputs[1].disabled = true;
        }
    }
}