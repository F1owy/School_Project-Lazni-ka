// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*const CardText = document.getElementById('cardtext');
let count = 0;
document.getElementById('cardbutton').addEventListener('click', () => {
    if (count % 2 == 0) {
        CardText.style.visibility = "hidden";
    } else {
        CardText.style.visibility = "visible";
    }
    count++;
});*/

/*const BoxPozadie = document.getElementById('boxpozadie');
const KlickCounter = document.getElementById('klickcounter');
let clickcount = 0;
document.getElementById('cardbuttoncolor').addEventListener('click', () => {
    clickcount++;
    KlickCounter.textContent = "Clicks: " + clickcount;
    if (clickcount >= 5) {
        BoxPozadie.style.backgroundColor = "blue";
    }
});*/


/*const ZnakCounter = document.getElementById('znakcounter');
const CardTextArea = document.getElementById('cardtextarea');
CardTextArea.addEventListener('keydown', () => {
    let znakcount = CardTextArea.value.length;
    ZnakCounter.textContent = "Počet znakov: " + znakcount;
    if (znakcount >= 20) {
        textarea.classList.add('uloha8-border-black');
        textarea.classList.remove('uloha8-border-red');
    } else {
        textarea.classList.add('uloha8-border-red');
        textarea.classList.remove('uloha8-border-black');
    }
});*/

/*const osoba = {
    meno: "Ján",
    vek: 25,
    mesto: "Bratislava"
};

const jsonString = JSON.stringify(osoba);

console.log(jsonString);*/


/*const jsonData = '[{ "nazov": "Notebook", "cena": 899 }, { "nazov": "Myš", "cena": 25 }, { "nazov": "Klávesnica", "cena": 45 }]';

const objekt = JSON.parse(jsonData);

console.log("Názov: " + objekt[0].nazov + " Cena: " + objekt[0].cena);*/

/*const jsonData = '{ "meno": "Ján", "oblubeneFilmy": ["Matrix", "Inception", "Interstellar"] }';

const objekt = JSON.parse(jsonData);

console.log(objekt.oblubeneFilmy[0] + "\n" + objekt.oblubeneFilmy[1] + "\n" + objekt.oblubeneFilmy[2] + "\n");*/

/*const jsonData = '[{ "meno": "Ján", "pozicia": Manažér }, { "meno": "Marta", "pozicia": Programátor }, { "meno": "Richard", "pozicia": Programátor }]';

const objekt = JSON.parse(jsonString);
const result = zamestnanci.filter(z => z.pozicia === "Programátor");
result.forEach(p => cosnole.log(p.meno));*/

/*const jsonData = '[{ "nazov": "Harry Potter", "autor": "J.K. Rowlingová" }, { "nazov": "Pán Prsteňov", "autor": "J.R.R. Tolkien" }, { "nazov": "1984", "autor": "George Orwell" }]';

const knihy = JSON.parse(jsonData);

function tableCreate() {
    const body = document.body,
        tbl = document.createElement('table');
    tbl.style.width = '100px';
    tbl.style.border = '1px solid black';
    tbl.style.margin = 'auto';

    for (let i = 0; i < knihy.length; i++) {
        const tr = tbl.insertRow();
        for (let j = 0; j < 2; j++) {
             
            const td = tr.insertCell();
            if (j % 2 == 0) {
                td.appendChild(document.createTextNode(knihy[i].nazov));
            } else {
                td.appendChild(document.createTextNode(knihy[i].autor));
            }
            
            td.style.border = '1px solid black';
            
        }
    }
    body.appendChild(tbl);
}

tableCreate();*/

/*const ImageMein = document.getElementById('imagemein');

document.getElementById('imgbutton').addEventListener('click', () => {
    fetch('https://api.thedogapi.com/v1/images/search')
        .then(response => response.json())
        .then(data => {
            console.log("Pes: ", data[0].url);
            ImageMein.src = data[0].url;
            ImageMein.style.height = "500px";
        })
        .catch(error => console.error('Chyba: ', error));
});*/

/*const jsonData = '[{ "nazov": "Harry Potter", "autor": "J.K. Rowlingová" }, { "nazov": "Pán Prsteňov", "autor": "J.R.R. Tolkien" }, { "nazov": "1984", "autor": "George Orwell" }]';

const knihy = JSON.parse(jsonData);

function tableCreate() {
    const body = document.body,
        tbl = document.createElement('table');
    tbl.style.width = '100px';
    tbl.style.border = '1px solid black';
    tbl.style.margin = 'auto';

    for (let i = 0; i < knihy.length; i++) {
        const tr = tbl.insertRow();
        for (let j = 0; j < 2; j++) {
             
            const td = tr.insertCell();
            if (j % 2 == 0) {
                td.appendChild(document.createTextNode(knihy[i].nazov));
            } else {
                td.appendChild(document.createTextNode(knihy[i].autor));
            }
            
            td.style.border = '1px solid black';
            
        }
    }
    body.appendChild(tbl);
}

tableCreate();*/