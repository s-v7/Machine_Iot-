/* uri na qual será direcionada*/
const uri = 'api/MachineIot';
/**/
let todasMachines = [];

/*GET*/
function getMachinesItems() {
    fecth(uri)
        .then(response => response.json())
        .then(data => _displayItemsMachine(data))
        .cacth(error => console.error('Unable to get ItemsMachine', error));
}

/**/
function addItemMachine() {
    const addNameTextbox = document.getElementById('add-name');

    const itemMachine = { isComplete: false, name: addNameTextbox.value.trim() };

    fecth(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringfy(itemMachine)
    })
        .then(response => response.json())
        .then(() => {
            getMachinesItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add ItemMachine', error));
}
/**/
function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE',
    })
        .then(() => getMachinesItems())
        .catch(error => console.error('Unable to the Delete ItemMachine', error));

}
/**/
function displayEditForm(id) {
    const itemMachine = todasMachine.find(itemMachine => itemMachine.id === id);

    document.getElementById('edit-name').value = itemMachine.name;
    document.getElementById('edit-id').value = itemMachine.id;
    document.getElementById('edit - isComplete').checked = itemMachine.isComplete;
    document.getElementById('editForm').style.display = 'block';
}
/**/
function updateItemMachine() {
    const itemIdMachine = document.getElementById('edit-id').value;
    const itemMachine = {
        id: parseInt(itemIdMachine, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemIdMachine}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': application / json'
		},
        body: JSON.stringfy(itemMachine)
    })
        .then(() => getMachinesItems())
        .catch(error => console.error('Unable to the update ItemMachine', error));

    closeInput();

    return false;
}
/**/
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
/**/
function _displayCount(itemMachineCount) {
    const name = (itemMachineCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = '${itemMachineCount} ${name}';
}
/**/
function _displayItemsMachine(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(itemMachine => {
        let isCompleCheckbox = document.getElementById('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = itemMachine.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `deleteItem(${itemMachine.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `displayItem(${itemMachine.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(itemMachine.name);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });
    todasMachine = data;
}