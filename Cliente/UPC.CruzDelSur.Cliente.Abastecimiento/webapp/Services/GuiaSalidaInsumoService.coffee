# GuiaSalidaInsumoService.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

abastecimiento.factory "GuiaSalidaInsumoService", ["$http", ($http) ->
    {
        getAll: () ->
            return $http.get "api/GuiaSalidaInsumo"

        getById: (id) ->
            return $http.get "api/GuiaSalidaInsumo/" + id

        getByDateRange: (fechaInicial, fechaFinal) ->
            return $http.get "api/GuiaSalidaInsumo?fechaInicial=" + fechaInicial + "&fechaFinal=" + fechaFinal

        save: (guiaSalidaInsumo) ->
            return $http.post "api/GuiaSalidaInsumo", guiaSalidaInsumo

        update: (guiaSalidaInsumo) ->
            return $http.put "api/GuiaSalidaInsumo", guiaSalidaInsumo
    }
]