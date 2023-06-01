function createGrid(date1, date2, interval)
{
    let row = document.createElement("div");
    row.classList.add("row", "row-cols-auto");
    while(true) {
        const col = document.createElement("div");
        let hour = date1.getHours();
        let minute = date1.getMinutes();
        hour = hour < 10 ? "0" + hour : hour;
        minute = minute == 0 ? "00" : minute;
        col.textContent = `${hour}:${minute}`;
        col.classList.add("cell", "col");
        row.appendChild(col);        
        date1.setMinutes(date1.getMinutes() + interval);
        if (date1 >= date2)
            break;
    }
    document.getElementById("mainContainer").appendChild(row);
}
// => YYYY-MM-DD
function formatDate(date)
{
    let month = date.getMonth() + 1;
    let day = date.getDate();
    month = month < 10 ? "0" + month : month;
    day = day < 10 ? "0" + day : day; 
    return `${date.getFullYear()}-${month}-${day}`;
}

function createCalendar()
{
    const calendar = document.getElementById("calendar");
    let now = new Date();
    calendar.setAttribute("min", formatDate(now));
    let max = new Date(now);
    max.setMonth(now.getMonth() + 2);
    calendar.setAttribute("max", formatDate(max));
}

const date1 = new Date(2023, 5, 24, 8, 0);
const date2 = new Date(2023, 5, 24, 17, 0);
createCalendar();
calendar.onchange = () => {
    createGrid(date1, date2, 20);
};