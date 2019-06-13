﻿

<section>
    <h1>Scope</h1>

    <pre>
        <code class="js">
            var variable = 'Test'; // globale

            function localScopeExample() {
                console.log(variable);
            }
        </code>
    </pre>

    <pre>
        <code class="js">
            function localScopeExample() { // una function crea Scope
                // LOCAL SCOPE
                var variable = 'Test';
                console.log(variable);
            }

            console.log(variable); // Uncaught ReferenceError
        </code>
    </pre>

    <pre>
        <code class="js">
            function func1() {
                var cat = 'Jerry';
                console.log(cat); // Jerry
            }

            function func2(){
                var cat = 'Tom';
                console.log(cat); // Tom
            }
        </code>
    </pre>

    <pre>
        <code class="js">
            var a = 1;

            function testIfScope() {
                if (true) {
                    var a = 4;
                }

                alert(a); // 4 non 1. In javascript solo le Function creano scope
            }
        </code>

    <button type="button" onclick="testLocalOverride()">Prova</button>

    <span type="text">* I browser più recenti supportano le ultime sintassi javascript e creando una variabile con <b>let</b> anche i blocchi fanno scope</span>
    </pre>

    <script>
        function testLocalOverride() {
            var a = 1;

            alert('variabile a globale parte da ' + a)

            function testIfScope() {
                if (true) {
                    var a = 4;
                    alert('sono la variabile a nel ramo true e sono stata reinizializzata con valore ' + a)
                }

                alert('sono la variabile a fuori dal if e ho come valore ' + a) // 4 non 1. In javascript solo le Function creano scope
            }

            testIfScope();
        }
    </script>

    <h3>Self-Invoking Functions</h3>

    <h3>Namespaces</h3>

</section>

<br />

<section>
    <h1>Truly / Falsy value</h1>

    <h4>True values</h4>
    <ul>
        <li>false</li>
        <li>(zero)</li>
        <li>Infinity</li>
        <li>'' or "" (empty string)</li>
        <li>null</li>
        <li>undefined</li>
        <li>NaN</li>
    </ul>

    <h4>False values</h4>
    <ul>
        <li>0</li>
        <li>false</li>
        <li>[]</li>
        <li>{}</li>
        <li>function() {}</li>
    </ul>

    <h3>Attenzione! Casi particolari:</h3>
    <pre>
        <code class="js">
            console.log( typeof(NaN) );
            console.log( NaN == NaN );
        </code>
        <label>output:</label>
        <code class="js" style="background-color:#454545; color:#EEEEEE; margin-top:0;">
            number
            false
        </code>
    </pre>
    <pre>
        <code class="js">
            console.log( Infinity ? true : false );
            console.log( Infinity == true );
            console.log( Infinity == false );
        </code>
        <label>output:</label>
        <code class="js" style="background-color:#454545; color:#EEEEEE; margin-top:0;">
            true
            false
            false
        </code>
    </pre>
    <pre>
        <code class="js">
            console.log( [] ? true : false );
            console.log( [] == true );
            console.log( [] == false );
        </code>
        <label>output:</label>
        <code class="js" style="background-color:#454545; color:#EEEEEE; margin-top:0;">
            true
            false
            true
        </code>
    </pre>

    <h4>Equals Operator ( == ) vs Strict Equals Operator ( === )</h4>
    <pre>
    <code class="js">
            if(1 == "1") { // usando == ritorna true usando === ritorna false
                alert('true')
            } else alert('false')
        </code>
    <label>esempio:</label>
    <code class="js">
            console.log( [] === true );
            console.log( [] === false );
        </code>
    <label>output:</label>
    <code class="js" style="background-color:#454545; color:#EEEEEE; margin-top:0;">
            false
            false
        </code>
    </pre>

</section>

<br />

<section>
    <h1>This</h1>

    <script>
        var name = "Name";

        function testThis() {
            alert(this.name); // se non bindato this va sul global scope, cioè window
        }
    </script>

    <pre>
        <code class="js">
            var name = "Name";

            function testThis() {
                alert( this.name ); // se non bindato this va sul global scope, cioè window
            }
        </code>
    <button onclick="testThis()">Prova</button>
    </pre>

    <pre>
        <code class="js">
            var persona = {
                nome: "Alberto",
                cognome: "Bottarini",

                stampaNomeCognome: function() {
                    alert(this.nome + "n" + this.cognome)
                }
            }
            persona.stampaNomeCognome();
        </code>
    </pre>

    <pre>
        <code class="js">
            var persona = function(nome, cognome) {
                this.nome = nome;
                this.cognome = cognome;
                this.stampaNomeCognome = function() {
                    alert(this.nome + "n" + this.cognome)
                }
            }
            var a = new persona("Alberto", "Bottarini");
            a.stampaNomeCognome();
        </code>
    </pre>

</section>

<br />

<section>
    <h1>Ajax</h1>

    <pre>
        <span>GET all Items: /api/Item</span>
        <code class="js">
            function getAllItem() {
                $.ajax({ url: '/api/Item', method: 'GET', dataType: 'JSON' })
                    .then(function (data) {
                        let content = 'I GOT:';
                        if (data != '') {
                            data.forEach(e => {
                                content += `\n--- -- ---\nItemId: ${e.ItemID}\nItemName: ${e.NamaItem}`;
                            });
                            alert(content);
                        }
                    });
            }
        </code>
        <button type="button" onclick="getAllItem()">Prova</button>
    </pre>

    <pre>
        <span>GET Item by id: /api/Item/id  id= <input type="number" id="itemid" style="width:50px;" /></span>
        <code class="js">
            function getItemByID() {
                var itemid = document.getElementById('itemid').value;

                $.ajax({
                    url: `/api/Item/${itemid}`, method: 'GET', dataType: 'JSON',
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        let content = 'I GOT:';
                        if (data != '') {
                            content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                            alert(content);
                        }
                    });
            }
        </code>
        <button type="button" onclick="getItemByID()">Prova</button>
    </pre>

    <pre>
        <span>Create new Item: /api/Item</span>
        <span>New Item Id= <input type="number" id="newItemId" style="width:50px;" />     New Item Name= <input type="text" id="newItemName" /></span>
        <code class="js">
            function createNewItem() {
                var newItemId = document.getElementById('newItemId').value;
                var newItemName = document.getElementById('newItemName').value;
                var newItem = { NamaItem: newItemName, ItemID: newItemId };

                $.ajax({
                    url: `/api/Item/`,
                    method: 'POST',
                    data: newItem,
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        let content = 'I POSTed:';
                        if (data != '') {
                            content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                            alert(content);
                        }
                    });
            }
        </code>
        <button type="button" onclick="createNewItem()">Prova</button>
    </pre>

    <pre>
        <span>Edit Item: /api/Item/id</span>
        <span>Item Id= <input onchange="getMyItemName('editItemId', 'editItemName')" type="number" id="editItemId" style="width:50px;" />     Item Name= <input type="text" id="editItemName" /></span>
        <code class="js">
            function getMyItemName(deleteItemid, setValueForId) { // onchange (Item id input)
                var itemId = document.getElementById(deleteItemid).value;

                $.ajax({
                    url: `/api/Item/${itemId}`, method: 'GET',
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        if (data != '') {
                            document.getElementById(setValueForId).value = data.NamaItem;
                        }
                    });
            }

            function editItem() {
                var itemId = document.getElementById('editItemId').value;
                var itemName = document.getElementById('editItemName').value;
                var updateItem = { NamaItem: itemName, ItemID: itemId };

                $.ajax({
                    url: `/api/Item/${itemId}`,
                    method: 'PUT',
                    data: updateItem,
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        let content = 'I PUT (updated):';
                        if (data != '') {
                            content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                            alert(content);
                        }
                    });
            }
        </code>
        <button type="button" onclick="editItem()">Prova</button>
    </pre>

    <pre>
        <span>DELETE Item by id: /api/Item/id   id= <input onchange="getMyItemName('deleteItemid' ,'deleteItemName')" type="number" id="deleteItemid" style="width:50px;" /></span>
        <span>Delete the Item with name: <input disabled id="deleteItemName" style="width:129px;"/></span>
        <code class="js">
            function getMyItemName(getItemIdFrom, setValueForId) { // onchange (Item id input)
                var itemId = document.getElementById(getItemIdFrom).value;

                $.ajax({
                    url: `/api/Item/${itemId}`, method: 'GET',
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        if (data != '') {
                            document.getElementById(setValueForId).value = data.NamaItem;
                        }
                    });
            }

            function deleteItemByID() {
                var itemId = document.getElementById('deleteItemid').value;

                $.ajax({
                    url: `/api/Item/${itemId}`, method: 'DELETE',
                    error: function (xhr, textStatus, errorThrown) {
                        alert(`Error: ${errorThrown}\nSomething went wrong!`);
                    }
                })
                    .then(function (data) {
                        let content = 'I DELETEd:';
                        if (data != '') {
                            content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                            alert(content);
                        }
                    });
            }
        </code>
        <button type="button" onclick="deleteItemByID()">Prova</button>
    </pre>
</section>

<script>

    function getAllItem() {
        $.ajax({ url: '/api/Item', method: 'GET' })
            .then(function (data) {
                let content = 'I GOT:';
                if (data != '') {
                    data.forEach(e => {
                        content += `\n--- -- ---\nItemId: ${e.ItemID}\nItemName: ${e.NamaItem}`;
                    });
                    alert(content);
                }
            });
    }

    function getItemByID() {
        var itemId = document.getElementById('itemid').value;

        $.ajax({
            url: `/api/Item/${itemId}`, method: 'GET',
            error: function (xhr, textStatus, errorThrown) {
                alert(`Error: ${errorThrown}\nSomething went wrong!`);
            }
        })
            .then(function (data) {
                let content = 'I GOT:';
                if (data != '') {
                    content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                    alert(content);
                }
            });
    }

    function createNewItem() {
        var newItemId = document.getElementById('newItemId').value;
        var newItemName = document.getElementById('newItemName').value;
        var newItem = { NamaItem: newItemName, ItemID: newItemId };
 
        $.ajax({
            url: `/api/Item/`,
            method: 'POST',
            data: newItem,
            error: function (xhr, textStatus, errorThrown) {
                alert(`Error: ${errorThrown}\nSomething went wrong!`);
            }
        })
            .then(function (data) {
                let content = 'I POSTed:';
                if (data != '') {
                    content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                    alert(content);
                }
            });
    }
    
    function getMyItemName(getItemIdFrom, setValueForId) {
        var itemId = document.getElementById(getItemIdFrom).value;

        $.ajax({
            url: `/api/Item/${itemId}`, method: 'GET',
            error: function (xhr, textStatus, errorThrown) {
                alert(`Error: ${errorThrown}\nSomething went wrong!`);
            }
        })
            .then(function (data) {
                if (data != '') {
                    document.getElementById(setValueForId).value = data.NamaItem;
                }
            });
    }

    function editItem() {
        var itemId = document.getElementById('editItemId').value;
        var itemName = document.getElementById('editItemName').value;
        var updateItem = { NamaItem: itemName, ItemID: itemId };

        $.ajax({
            url: `/api/Item/${itemId}`,
            method: 'PUT',
            data: updateItem,
            error: function (xhr, textStatus, errorThrown) {
                alert(`Error: ${errorThrown}\nSomething went wrong!`);
            }
        })
            .then(function (data) {
                let content = 'I PUT (updated):';
                if (data != '') {
                    content += `\n--- -- ---\nItemId: ${data.ItemID}\nItemName: ${data.NamaItem}`;
                    alert(content);
                }
            });
    }

    function deleteItemByID() {
        var itemId = document.getElementById('deleteItemid').value;

        $.ajax({
            url: `/api/Item/${itemId}`, method: 'DELETE',
            error: function (xhr, textStatus, errorThrown) {
                alert(`Error: ${errorThrown}\nSomething went wrong!`);
            }
        })
            .then(function (data) {
                let content = 'Item DELETEd!';
                if (data) {
                    alert(content);
                }
            });
    }
</script>

<style type="text/css">
    code:active
    {
        font-size: 135%;
        height: 135%;
    }
    code:hover
    {
        cursor:zoom-in;
    }
</style>