const days = [  {
                    dayOfWeek : "Montag",
                    von : "08:00",
                    bis : "17:00"
                },
                {
                    dayOfWeek : "Dienstag",
                    von : "08:00",
                    bis : "17:00"
                },
            ];

function createSchedule()
{
    for (let i = 0; i < days.length; i++) {
        
        var row =   `<div class="schedulerow row">
                        <div class="col-1">${days[i].dayOfWeek}</div>
                        <div class="col-1">von</div>
                        <div class="col-1">
                            <input type="time" id="${days[i].dayOfWeek}Von" value="${days[i].von}" step="3600">
                        </div>
                        <div class="col-1">bis</div>
                        <div class="col-1">
                            <input type="time" id="${days[i].dayOfWeek}Bis" value="${days[i].bis}" step="3600">
                        </div>
                        <div class="col-2">
                            <input type="checkbox" id="${days[i].dayOfWeek}Ausgang">
                            <label for="MontagAusgang">Kein Werktag</label>
                        </div>
                    </div>`
        document.getElementById("mainContainer").innerHTML += row;
    
    }
}

createSchedule();