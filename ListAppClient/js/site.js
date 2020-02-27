const URL = 'https://localhost:5001/api/Items';

const allItemsUL = document.querySelector('#allItems');
const form = document.querySelector('#add-item-form');


const getItems = () => {
  fetch(URL)
    .then((response) => {
      return response.json();
    })
    .then((myJson) => {
      writeItems(myJson);
    });
}

const writeItems = items => {

  allItemsUL.innerHTML = '';

  items.forEach(element => {
    console.dir(element);
    const li = document.createElement('li');
    li.innerHTML = `${element.id} - ${element.name} - ${element.isComplete}`;

    allItemsUL.append(li);
  });

};

const handleForm = e => {
  e.preventDefault();

  const item = {
    name: e.target.name.value,
    isComplete: e.target.iscomplete.checked ? 1 : 0,
  }


  fetch(URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(item),
  })
    .then((response) => response.json())
    .then((item) => {
      console.log('Success:', item);
    })
    .then(() => {
      getItems();
    })
    .catch((error) => {
      console.error('Error:', error);
    });

};

form.addEventListener('submit', handleForm);

getItems();