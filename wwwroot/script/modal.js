const CodLocal = document.querySelector('#IdLocal').value

const buttons = {
    readResponsaveis: document.querySelector('#ButtonResponsaveis'),
    createResponsavel: document.querySelector('#ButtonCreateResponsavel'),

    readEmails: document.querySelector('#ButtonEmails'),
    createEmail: document.querySelector('#ButtonCreateEmail'),

    readTelefones: document.querySelector('#ButtonTelefones'),
    createTelefone: document.querySelector('#ButtonCreateTelefone'),
}

// ----- // Responsáveis

buttons.readResponsaveis.onclick = async () => {
        
    const modal = document.querySelector('#ModalResponsaveis table')
    modal.innerHTML = `
        <tr>
            <td scope="col">Id</td>
            <td scope="col">Nome</td>
            <td scope="col">&ensp;</td>
        </tr>
        `
    $(function (){
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/locais/responsaveis/",
            data: {CodLocal: CodLocal},
            success: function (dados){
                // console.log(dados)
                $(dados).each(function (i){
                    // console.log(dados[i])
                    modal.innerHTML += `
                    <tr id="linha_responsavel${dados[i].idResponsavel}>
                        <th>${dados[i].idResponsavel}</th>
                        <th>${dados[i].responsavel}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('responsavel', ${dados[i].idResponsavel}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                })
                
            }

        })

    })

}

buttons.createResponsavel.onclick = async () => {

    const modal = document.querySelector('#ModalResponsaveis table')
    const Responsavel = document.querySelector('#InputModalResponsaveis').value

    $(function (){
        $.ajax({
            dataType: "json",
            type: "POST",
            url: "/locais/createresponsavel/",
            data:{
                Responsavel: Responsavel,
                CodLocal: CodLocal
            },
            success: function (dados){
                // console.log(dados)
                modal.innerHTML += `
                    <tr id="linha_responsavel${dados.idResponsavel}>
                        <th>${dados.idResponsavel}</th>
                        <th>${dados.responsavel}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('responsavel', ${dados.idResponsavel}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                Responsavel = ''
            }

        })

    })

}

// ----- // Emails

buttons.readEmails.onclick = async () => {
        
    const modal = document.querySelector('#ModalEmails table')
    modal.innerHTML = `
        <tr>
            <td scope="col">Id</td>
            <td scope="col">Email</td>
            <td scope="col">&ensp;</td>
        </tr>
        `
    $(function (){
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/locais/emails/",
            data: {CodLocal: CodLocal},
            success: function (dados){
                // console.log(dados)
                $(dados).each(function (i){
                    // console.log(dados[i])
                    modal.innerHTML += `
                    <tr id="linha_email${dados[i].idEmail}>
                        <th>${dados[i].idEmail}</th>
                        <th>${dados[i].email}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('email', ${dados[i].idEmail}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                })
                
            }

        })

    })

}

buttons.createEmail.onclick = async () => {

    const modal = document.querySelector('#ModalEmails table')
    const Email = document.querySelector('#InputModalEmails').value

    $(function (){
        $.ajax({
            dataType: "json",
            type: "POST",
            url: "/locais/createemail/",
            data:{
                Email: Email,
                CodLocal: CodLocal
            },
            success: function (dados){
                // console.log(dados)
                modal.innerHTML += `
                    <tr id="linha_email${dados.idEmail}>
                        <th>${dados.idEmail}</th>
                        <th>${dados.email}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('email', ${dados.idEmail}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                Email = ''
            }

        })

    })

}

// ----- // Telefones

buttons.readTelefones.onclick = async () => {
        
    const modal = document.querySelector('#ModalTelefones table')
    modal.innerHTML = `
        <tr>
            <td scope="col">Id</td>
            <td scope="col">Telefone</td>
            <td scope="col">&ensp;</td>
        </tr>
        `
    $(function (){
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/locais/telefones/",
            data: {CodLocal: CodLocal},
            success: function (dados){
                // console.log(dados)
                $(dados).each(function (i){
                    // console.log(dados[i])
                    modal.innerHTML += `
                    <tr id="linha_telefone${dados[i].idTelefone}">
                        <th>${dados[i].idTelefone}</th>
                        <th>${dados[i].telefone}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('telefone', ${dados[i].idTelefone}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                })
                
            }

        })

    })

}

buttons.createTelefone.onclick = async () => {

    const modal = document.querySelector('#ModalTelefones table')
    const Telefone = document.querySelector('#InputModalTelefones').value

    $(function (){
        $.ajax({
            dataType: "json",
            type: "POST",
            url: "/locais/createtelefone/",
            data:{
                Telefone: Telefone,
                CodLocal: CodLocal
            },
            success: function (dados){
                // console.log(dados)
                modal.innerHTML += `
                    <tr id="linha_telefone${dados.idTelefone}">
                        <th>${dados.idTelefone}</th>
                        <th>${dados.telefone}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" onclick="deletar('telefone', ${dados.idTelefone}, ${modal})">Excluir</button></th>
                    </tr>
                    `
                Telefone = ''
            }

        })

    })

}

// ----- // Deletar

function deletar(tabela, id, modal){

    console.log(tabela, id)

    $.ajax({
        dataType: "json",
        type: "POST",
        url: `/locais/delete${tabela}/${id}`,
        success: function (id){ // retorna o ID aqui do item que foi excluido pls

            console.log(id)
            const linha = modal.querySelector(`#linha_${tabela}${id}`)
            // linha.style.display = 'none'
            linha.remove() // Isso deveria excluir o elemento html, mas se não funcionar, descomenta a linha de cima :)

        }
    })

}