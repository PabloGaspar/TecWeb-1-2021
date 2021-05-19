window.addEventListener('DOMContentLoaded', function(event){

    let teams = [];
    const baseUrl = 'http://localhost:3030/api';

    /*function fetchTeams()
    {
        debugger;
        const url = `${baseUrl}/teams`;
        let status;
        fetch(url)
        .then((response) => { 
            status = response.status;
            return response.json();
        })
        .then((data) => {
            if(status == 200)
            {
                console.log(data)
                let teamsLi = data.map( team => { return `<li> Name: ${team.name} | City: ${team.city} | DT: ${team.dtname} </li>`});
                var teamContent = `<ul>${teamsLi.join('')}</ul>`;
                document.getElementById('teams-container').innerHTML = teamContent;
            } else {
                alert(data);
            }
        });
    }*/

    async function fetchTeams()
    {
        const url = `${baseUrl}/teams`;
        let response = await fetch(url);
        try{
            if(response.status == 200){
                let data = await response.json();
                let teamsLi = data.map( team => { return `<li> Name: ${team.name} | City: ${team.city} | DT: ${team.dtname} </li>`});
                var teamContent = `<ul>${teamsLi.join('')}</ul>`;
                document.getElementById('teams-container').innerHTML = teamContent;
            } else {
                var errorText = await response.text();
                alert(errorText);
            }
        } catch(error){
            var errorText = await error.text();
            alert(errorText);
        }
    }

    function PostTeam(event)
    {
        debugger;
        event.preventDefault();
        let url = `${baseUrl}/teams`;
        
        if(!event.currentTarget.dtName.value)
        {
            event.currentTarget.dtName.style.backgroundColor = 'red';
            return;
        }

        var data = {
            Name: event.currentTarget.name.value,
            FundationDate: event.currentTarget.fundationDate.value,
            City: event.currentTarget.city.value,
            DTName: event.currentTarget.dtName.value
        };

        fetch(url, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => {
            if(response.status === 201){
                alert('team was created');
            } else {
                response.text()
                .then((error)=>{
                    alert(error);
                });
            }
        });
        

    }
    
    document.getElementById('fetch-btn').addEventListener('click', fetchTeams);
    document.getElementById('create-team-frm').addEventListener('submit', PostTeam)
});

//https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/