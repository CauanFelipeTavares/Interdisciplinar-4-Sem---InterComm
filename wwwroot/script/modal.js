const CodLocal = document.querySelector('#IdLocal').value

const buttonResponsavel = document.querySelector('#ButtonResponsaveis')
//LER RESPONSAVEIS
buttonResponsavel.onclick = async () => {
        
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
                    <tr>
                        <th>${dados[i].idResponsavel}</th>
                        <th>${dados[i].responsavel}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button">Excluir</button></th>
                    </tr>
                    `
                })
                
            }

        })

    })

}

const buttonAdicionarResponsavel = document.querySelector('#ButtonModalResponsaveis')
//ADICIONAR RESPONSAVEIS
buttonAdicionarResponsavel.onclick = async () => {

    const Input = document.querySelector('#InputModalResponsaveis')

    const Responsavel = Input.value
    const modal = document.querySelector('#ModalResponsaveis table')

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
                    <tr>
                        <th>${dados.idResponsavel}</th>
                        <th>${dados.responsavel}</th>
                        <th class="text-end"><button class="btn btn-danger btn-sm" type="button" value="${dados.idResponsavel}">Excluir</button></th>
                    </tr>
                    `
                Input.value = ''
            }

        })

    })

}