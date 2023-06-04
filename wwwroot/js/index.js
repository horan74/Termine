function createGrid(date1, date2, interval)
{
    const grid = document.createElement("div");
    grid.classList.add("row", "row-cols-auto");
    const copiedDate1 = new Date(date1.getTime());
    const copiedDate2 = new Date(date2.getTime());
    while(true) {
        const col = document.createElement("div");
        let hour = copiedDate1.getHours();
        let minute = copiedDate1.getMinutes();
        hour = hour < 10 ? "0" + hour : hour;
        minute = minute == 0 ? "00" : minute;
        col.textContent = `${hour}:${minute}`;
        col.classList.add("cell", "col");
        grid.appendChild(col);        
        copiedDate1.setMinutes(copiedDate1.getMinutes() + interval);
        if (copiedDate1 >= copiedDate2)
            break;
    }
    return grid;
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
    const calendar = document.createElement("input");
    calendar.setAttribute("type", "date");
    calendar.setAttribute("id", "calendar");
    let now = new Date();
    calendar.setAttribute("min", formatDate(now));
    let max = new Date(now);
    max.setMonth(now.getMonth() + 2);
    calendar.setAttribute("max", formatDate(max));
    calendar.value = formatDate(now);
    return calendar;
}

const mainContainer = document.getElementById("mainContainer");
mainContainer.innerHTML = '';
mainContainer.appendChild(createCalendar());

fetch("/", { 
    method: "POST", 
    headers: { "Accept": "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
        date: document.getElementById("calendar").value
    })
});
// const date1 = new Date(2023, 6, 4, 8, 0);
// const date2 = new Date(2023, 6, 4, 17, 0);
// createGrid(date1, date2, 20);
// const calendar = document.getElementById("calendar");
// calendar.onchange = () => {
//     createGrid(date1, date2, 20);
// };