<template>
    <div class="vistaPrincipal">
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!------------------------------------------------Modales------------------------------------------------>

                <!--Modal crear Tarea-->

                <div class="modal fade" id="staticBackdrop" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Crear Tarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="taskName" required style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    
                                    </div>
                                    <br>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div style="margin-top: 15px;">
                                                <input v-model="taskDescription" required style="border-radius: 5px;" type="textarea" placeholder="Descripción">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="createTask" type="button" class="btn btn-success" data-bs-dismiss="modal">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal editar Tarea-->
                <div class="modal fade" id="editarTarea" tabindex="-1" aria-labelledby="editarTarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Editar Tarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="taskNameUnderEdit" required style="border-radius: 5px;" maxLength="45" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                            <br/>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div>
                                                <input v-model="taskDescriptionUnderEdit" required style="border-radius: 5px;" maxLength="100" type="textarea" placeholder="Descripcion...">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br/>
                                <div>
                                    <label>Estado<span style="color: red;"> *</span></label>
                                    <br />
                                    <!--:selected="currentTask?.Task_State === 'Finalizada'" -->
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="taskStateUnderEdit" required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option value="Pendiente" >Pendiente</option>
                                            <option value="En Proceso" >En Proceso</option>
                                            <option value="Finalizada" >Finalizada</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="editCurrentTask" type="button" class="btn btn-success" data-bs-dismiss="modal">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal editar Tarea-->

                <!--Modal eliminar Tarea-->

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Tarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar la tarea?</p>
                                </div>
                                <div>
                                    <label>Digite su contraseña</label>
                                    <br />
                                    <div class="row" style="margin-top: 15px;">
                                        <input v-model="verifyPassword" class="col-10" style="margin-left: 10px; border-radius: 5px;" type="password"
                                            required placeholder="Contraseña">
                                        <button @click="getPasswordVerifyDeleteRow()" type="button" class="btn btn-success col-1" style="margin-left: 5px;"><span
                                                class="fas fa-check"></span></button>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="deleteRowList()"  class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Modal eliminar Tarea-->

                <!--Modal Ver Tarea-->

                <div class="modal fade" id="verTarea" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="verTarea" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-scrollable modal-xl">
                        <div class="modal-content bg-gradient-gray">
                            <div class="modal-header">
                                <div class="col-12">
                                    <div class="row" style="text-align: right;">
                                        <div class="col-md-12 col-xs-12">
                                            <button style="border: none; background-color: transparent; min-height: 15px; min-width: 25px; font-size: 30px;" type="button" data-bs-dismiss="modal">&times;</button>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="modal-body">
                                <div class="col-md-12 col-xs-12" style="min-height: 350px; max-height: 400px">
                                    <div>
                                        <div class="col-12">
                                            <h1 style="text-align:center"><strong>{{ currentTask ? currentTask.Task_Name : '' }}</strong></h1>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="col-md-12 col-xs-12" style="min-height: 350px; max-height: 400px">
                                        <div class="row">
                                            <div class="col-12">
                                                <h4 class="modal-title" style="text-align: center"><strong>Descripción</strong></h4>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="col-md-12 col-xs-12">
                                                    <div style="text-align: justify;">
                                                        {{ currentTask ? currentTask.Description_Task : '' }}
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br>

                                        <div class="row justify-content-center" style="position: relative;">

                                        </div>

                                        <br />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal Ver Tarea-->

                <!--Modal crear Subtarea-->

                <div class="modal fade" id="crearSubtarea" tabindex="-1" aria-labelledby="crearSubtarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Crear Subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Título</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción</label>
                                            <div>
                                                <div ref="Quill" style="border: 1px solid gray; min-height: 200px; border-bottom-left-radius: 15px; border-bottom-right-radius: 15px;"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Estado</label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option value="1">Pendiente</option>
                                            <option value="2">En Proceso</option>
                                            <option value="3">Finalizada</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Tiempo requerido</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="number" placeholder="1">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Prioridad</label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option value="1">Alta</option>
                                            <option value="2">Media</option>
                                            <option value="3">Baja</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal crear Subtarea-->

                <!--Modal editar Subtarea-->

                <div class="modal fade" id="editarSubtarea" tabindex="-1" aria-labelledby="editarSubtarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Editar Subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Título</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción</label>
                                            <div>
                                                <div ref="Quill" style="border: 1px solid gray; min-height: 200px; border-bottom-left-radius: 15px; border-bottom-right-radius: 15px;"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Estado</label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option value="1">Pendiente</option>
                                            <option value="2">En Proceso</option>
                                            <option value="3">Finalizada</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Tiempo requerido</label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input required style="border-radius: 5px;" type="number" placeholder="1">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Prioridad</label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option value="1">Alta</option>
                                            <option value="2">Media</option>
                                            <option value="3">Baja</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal editar Subtarea-->

                <!--Modal eliminar Subtarea-->

                <div class="modal fade" id="eliminarSubtarea" tabindex="-1" aria-labelledby="eliminarSubtarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Eliminar Subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea eliminar la subtarea?</p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal eliminar Subtarea-->

                <!------------------------------------------------Modales------------------------------------------------>

                <!--Menú Lateral /-->

                <MenuLateral />

                <!--Menú Lateral /-->

                <div class="w-100 listadoGeneral">

                    <!--Filtros responsive /-->

                    <div class="row justify-content-center filtrosCelularBotones">
                        <div class="col-5"></div>
                        <div class="col-2 filtrosCelularBoton" v-if="!filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-gradient-yellow-orange-black fas fa-bars"></a>
                        </div>
                        <div class="col-5"></div>
                    </div>

                    <div class="filtrosCelular row justify-content-center" v-if="filtroDesplegar">

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Inicio' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Proyectos&nbsp;&nbsp;<i class="text-white fas fa-project-diagram" style="cursor: pointer; font-size: 14px;"></i></router-link>
                            </div>
                        </div>
                        
                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Encuestas' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Encuestas&nbsp;&nbsp;<i class="text-white fas fa-chart-line" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 row justify-content-center" style="margin-top: 40px;">
                            <div class="col-8 textoBlanco" style="text-align: center;">
                                <router-link role="button" :to="{ name: 'Reportes' }" class="textoBlanco textoEncuestas" style="text-decoration: none;" exact-active-class="active-link">Reportes&nbsp;&nbsp;<i class="text-white far fa-file-alt" style="cursor: pointer;"></i></router-link>
                            </div>
                        </div>

                        <div style="text-align: center; font-size: large; padding-top: 40px; cursor: pointer; margin-left: 20px;" v-if="filtroDesplegar" v-on:click="desplegarFiltros()">
                            <a class="text-white fas fa-angle-up" style="text-decoration: none;"></a>
                        </div>

                    </div>

                    <!--Filtros responsive /-->

                    <div class="w-100 vld-parent col-12" style="min-height: 85vh;">

                        <!--Lista de Tareas /-->

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px;">
                            <div class="col-12 estiloTabla tableHeight" style="padding:15px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Sprints' }"><span class="fas fa-arrow-left"></span></router-link>
                                        </ul>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Tareas</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <a class="li agregarBlt agregarResponsive" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span> Crear Tarea</a>
                                            <a class="li agregarBlt agregarResponsivePlus" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span></a>
                                        </ul>
                                    </div>

                                    <div class="row">
                                        
                                        <div class="col-4">
                                            <div>
                                                <a class="text-black fas fa-check-square" style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Estado</label>
                                            </div>
                                            <select class="form-select diseñoSelectLateral" v-model="Filtros.estado">
                                                <option value="">Todos</option>
                                                <option value="1" >Activa</option>
                                                <option value="2" >Inactiva</option>
                                                <option value="3" >Pendiente</option>
                                                <option value="4" >En Proceso</option>
                                                <option value="5" >Finalizada</option>
                                            </select>
                                        </div>

                                        <div class="col-6">
                                            <div>
                                                <a class="text-black fas fa-pen-square"
                                                    style="text-decoration: none;"></a>
                                                <label class="text-black p-3 Td">Palabra</label>
                                            </div>
                                            <div>
                                                <input autocomplete="off" maxlength="70" class="diseñoSelectLateral" type="search" id="pClaveInput" placeholder="Buscar" v-model="Filtros.palabra">
                                            </div>
                                        </div>

                                        <div class="col-2">
                                            <div>
                                                <label class="text-white p-3 Td">.</label>
                                            </div>
                                            <div>
                                                <button type="button" class="btn btn-success" style="float: right;" @click="aplyFilter(Filtros.estado, Filtros.palabra)"><span class="fas fa-search"></span></button>
                                            </div>
                                        </div>

                                    </div>

                                    <div v-if="paginateData.length == 0" class="sinResultadosAct">
                                        <p>No hay tareas para mostrar</p>
                                    </div>

                                    <div class="contenidoTabla" v-if="paginateData.length > 0">
                                        <!--<table class="table table-stryped" style="text-align: center;">
                                            <thead>
                                                <tr>
                                                    <th class="col-1" style="min-width: 75px;"># Tarea</th>
                                                    <th class="col-4" style="min-width: 150px;">Nombre</th>
                                                    <th class="col-1" style="min-width: 125px;">Estado</th>
                                                    <th class="col-2" style="min-width: 125px;">Opciones</th>
                                                </tr>
                                            </thead>
                                            <tbody style="font-size: large;">
                                                <tr>
                                                    <td @click="mostrarSubtareas" class="claseTD">1</td>
                                                    <td @click="mostrarSubtareas" class="claseTD">Crear Login</td>
                                                    <td @click="mostrarSubtareas" class="claseTD">En proceso</td>
                                                    <td class="text-white">
                                                        <button class="btn btn-primary" role="button" @click="verTareas">
                                                            <span class="fas fa-eye" b-tooltip.hover title="Ver Tarea"></span>
                                                        </button>
                                                        <button style="margin-left: 5px;" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#editarTarea">
                                                            <span class="fas fa-pen" b-tooltip.hover title="Editar Tarea"></span>
                                                        </button>
                                                        <button type="button" class="btn btn-danger" style="margin-left: 5px;" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                            <span class="fas fa-trash" b-tooltip.hover title="Eliminar Tarea"></span>
                                                        </button>
                                                    </td>
                                                </tr>
                                                <tr class="collapse" id="collapseExample" :class="{ 'show': subtareas }">
                                                    <td colspan="4">
                                                        <div>
                                                            <table class="table" style="text-align: center;">
                                                                <tbody style="font-size: medium;">
                                                                    <tr class="listaSubtareas">
                                                                        <td>Diseño de la pantalla del login responsive</td>
                                                                    </tr>
                                                                    <tr class="listaSubtareas">
                                                                        <td>Validación de los campos</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>-->

                                        <div class="tablaPersonalizada">
                                            <div>
                                                <h6 style="cursor: default; min-width: 40px;"><b># Tarea</b></h6>
                                                <hr>
                                            </div>
                                            <div>
                                                <h6 style="cursor: default; color: white">.</h6>
                                                <hr>
                                            </div>
                                            <div>
                                                <h6 style="cursor: default;"><b>Nombre</b></h6>
                                                <hr>
                                            </div>
                                            <div>
                                                <h6 style="cursor: default;"><b>Estado</b></h6>
                                                <hr>
                                            </div>
                                            <div>
                                                <h6 style="cursor: default;"><b>Opciones</b></h6>
                                                <hr>
                                            </div>
                                        </div>
                                        <div>

                                            <div class="tablaPersonalizada" v-for="tarea in paginateData" :key="tarea.Id_Task">
                                                <div>
                                                    <div class="tablaPersonalizadaRow" @click="mostrarSubtareas">{{ tarea.Id_Task }}</div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow"><a style="text-decoration: none;" class="fas fa-plus" data-bs-toggle="modal" data-bs-target="#crearSubtarea"></a></div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow" @click="mostrarSubtareas">{{ tarea.Task_Name }}</div>
                                                </div>
                                                <div>
                                                    
                                                    <div v-if="tarea.Id_Status == 1" class="tablaPersonalizadaRow" @click="mostrarSubtareas">Activo</div>
                                                    <div v-if="tarea.Id_Status == 2" class="tablaPersonalizadaRow" @click="mostrarSubtareas">Inactivo</div> 
                                                    <div v-if="tarea.Id_Status == 3" class="tablaPersonalizadaRow" @click="mostrarSubtareas">Pendiente</div> 
                                                    <div v-if="tarea.Id_Status == 4" class="tablaPersonalizadaRow" @click="mostrarSubtareas">En Proceso</div> 
                                                    <div v-if="tarea.Id_Status == 5" class="tablaPersonalizadaRow" @click="mostrarSubtareas">Finalizada</div> 
                                                    
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow" style="min-width: 150px;">
                                                        <button  @click="() => selectCurrentTask(tarea)" class="btn btn-primary" role="button" data-bs-toggle="modal" data-bs-target="#verTarea">
                                                            <span class="fas fa-eye" b-tooltip.hover title="Ver Tarea"></span>
                                                        </button>
                                                        <button @click="() => startTaskEditing(tarea)" style="margin-left: 5px;" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#editarTarea">
                                                            <span class="fas fa-pen" b-tooltip.hover title="Editar Tarea"></span>
                                                        </button>
                                                        <button @click="() => deleteTask(tarea)" type="button" class="btn btn-danger" style="margin-left: 5px;" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                            <span class="fas fa-trash" b-tooltip.hover title="Eliminar Tarea"></span>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                            <br/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <nav v-if="paginate" aria-label="Page navigation example" style="position: absolute; bottom: 25px; margin-left: 25px;">
                                <ul class="pagination cursorPaginados">
                                    <li class="page-item"><a class="page-link" v-on:click="goBack()">Anterior</a></li>
                                    <li v-for="pagina in pageNumeration" v-bind:key="pagina" class="page-item">
                                        <a class="page-link" v-on:click="changePage(pagina)" v-bind:class="{ active: (pagina == actualPage) }">{{pagina}}</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" v-on:click="goNext()">Siguiente</a></li>
                                </ul>
                            </nav>
                        </div>

                        <!--Lista de proyectos /-->

                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Cookies from 'js-cookie';
import HeaderPrincipal from '@/components/HeaderPrincipal.vue'
import Quill from 'quill'
import MenuLateral from '@/components/MenuLateral.vue'
import AdminApi from '@/Api/Api';

export default {

    components: {
        /* eslint-disable */
        HeaderPrincipal, Quill, MenuLateral
        /* eslint-disable */
    },

    data() {
        return {
            filtroDesplegar: false,

            Filtros: {
                fechaI: "",
                fechaF: "",
                estado: "",
                usuario: "",
            },

            pageElements: 4,
            actualPage: 1,
            pageNumeration: [],
            paginate: true,
            paginateData: [],

            subtareas: false,
            tareas : [],
            currentTask: null,

            taskName: '',
            taskDescription: '',
            verifyPassword:"",

            // campos de edicion
            taskNameUnderEdit : '',
            taskDescriptionUnderEdit : '',
            taskStateUnderEdit : '',
            taskIdUnderEdit : null,

            // validacion de tarea
            validationMessage : '',
            confimPassworsDelete : '',

            currentSprintId : 0,
        }
    },

    methods: {

        EditarTarea: function(TareaID) {
            this.$router.push({
                name: "EditarTarea",
                params: {
                    id: TareaID,
                }
            })
        },

        async editCurrentTask() {
            let modifiedTask = {
                Task_Name : this.taskNameUnderEdit,
                Description_Task : this.taskDescriptionUnderEdit,
                // los que no cambian
                Id_Task : this.taskIdUnderEdit,
                Id_Sprint: this.currentTask.Id_Sprint,
                Id_Status: this.taskStateUnderEdit,
            }

            if (this.validateTask(modifiedTask, true) !== 'VALID') {
                return;
            }
            
            const result = await AdminApi.PutTask(modifiedTask);
            if (result.data.ok) {

                // limpiar campos
                this.taskNameUnderEdit = ''
                this.taskDescriptionUnderEdit = ''
                this.taskStateUnderEdit = ''

                this.$swal({ icon: 'success', text: 'Se creo correctamente la tarea' });
                console.log("Se edito la tarea correctamente");
                this.getTareasDesdeAPI(); 
                reload
            } else {
                console.log("Hubo un error al editar tarea");
            }
        },

        deleteRowList: async function () {
          
          try {

            const id = this.currentTask.Id_Task;

              if(this.confimPassworsDelete){
              const response = await AdminApi.PutTaskDisableStatus(id);
              const mensage=response.data.ok;
              location.reload()
                  
              }
              else
              {
                  this.$swal({ icon: 'warning', text: 'La contraseña que insertaste no es correcta' });
              }

          } catch (error) {
              console.error('Error al cargar las tareas desde la API:', error);
          }

      },

        validateTask(task, isEdit) {

            if (task.Task_Name.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'No se ingresó el nombre de la tarea',
                })
            }

            if (task.Description_Task.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'No se ingresó la descripción de la tarea',
                })
            }

            const validStates = [ "Pendiente", "En Proceso", "Finalizada" ]
            if (isEdit && !validStates.includes(task.Id_Status.trim())) {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que elegir un estado',
                })
            }

            return 'VALID';
        },

        async deleteTask(task) {
            this.currentTask = task

            // const id = task.Task_Id;
            // const result = await AdminApi.DeleteTask(modifiedTask);
            // if (result.data.ok) {
            //     console.log("Se borro la tarea correctamente");
            //     this.getTareasDesdeAPI(); // llamamos a get tareas
            // } else {
            //     console.log("Hubo un error al eliminar tarea");
            // }

        },

        mostrarSubtareas: function() {
            this.subtareas = !this.subtareas;
        },

        desplegarFiltros: function () {
            this.filtroDesplegar = !this.filtroDesplegar;
        },

        cerrarFiltros: function () {
            this.filtroDesplegar = false;
        },

        seleccionarAplicacion: async function() {
            await this.$root.designarAplicacionHeaderPrincipal.call();
        },

        cerrarMenu: async function () {
            await this.$root.CerrarMenu.call();
            await this.$root.CerrarMenuAplicaciones.call();
        },

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        recuperarUsuTipo() {
            return Cookies.get("tipoU")
        },

        recuperarUsuNombre() {
            return Cookies.get("nombreUsu")
        },

        verificarLog: function () {
            let login = this.recuperarUsuLog()
            let nombre = this.recuperarUsuNombre()
            if (login == null || (nombre == undefined || nombre == null || nombre == '')) {
                this.$router.push("/");
                this.$swal({ icon: 'warning', text: 'Aún no ha iniciado sesión, por favor verifique' });
            }

        },

        startTaskEditing(task) {
            this.selectCurrentTask(task);

            // cargar los campos para edicion
            this.taskIdUnderEdit = task.Id_Task;
            this.taskDescriptionUnderEdit = task.Description_Task;
            this.taskStateUnderEdit = task.Id_Status,
            this.taskNameUnderEdit = task.Task_Name
        },

        selectCurrentTask(task) {
            this.currentTask = task;
        },

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        getPasswordVerifyDeleteRow: async function () {
            let login = this.recuperarUsuLog()
            try {
                const response = await AdminApi.GetPasswordVerifyDeleteRow(login, this.verifyPassword);
                const mensage=response.data.ok;
                console.log( mensage == true ? "Se verifico" : "No se verifico")

                if(mensage==true){

                this.confimPassworsDelete=true
                this.$swal({ icon: 'success', text: 'Se verifico correctamente la contraseña' });
                    
                }
                else{
                    this.$swal({ icon: 'warning', text: 'La contraseña que insertaste no es correcta' });

                }

            } catch (error) {
                console.error('Error al cargar los proyectos desde la API:', error);
            }

        },

        async createTask() {
            const currentSprintId = localStorage.getItem("currentSprintId");
            const task = {
                Task_Name : this.taskName,
                Description_Task : this.taskDescription,
                Id_Sprint : currentSprintId,
            }

            if (this.validateTask(task, false) !== 'VALID') {
                return;
            }
            this.actualPage = 1
            await this.postTaskToAPI(task);
            this.tareas = []
            await this.getTareasDesdeAPI()
            await this.cutPages()
        },

        // async getTareasDesdeAPI() {
        //    const idSprint = localStorage.getItem("currentSprintId")
        //     try {
        //         const response = await AdminApi.GetAllTasks(idSprint);
        //         const Tasklist = response.data.obj;
        //         this.tareas = Tasklist;
        //         console.log(this.tareas);
        //     } catch (error) {
        //         console.error('Error al cargar las tareas desde la API:', error);
        //     }
        // },

        async getTareasDesdeAPI() {
            const idSprint = localStorage.getItem("currentSprintId")
            this.actualPage = 1
            try {
                if (this.tareas.length == 0) {
                    const response = await AdminApi.GetAllTasks(idSprint);
                    const Tasklist = response.data.obj;
                    this.tareas = Tasklist;
                    this.paginateData = [];
                    if(this.tareas.length < this.pageElements){
                        for (let index = 0; index < this.tareas.length; index++){
                            this.paginateData.push(this.tareas[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++){
                            this.paginateData.push(this.tareas[index]);
                        }
                    }
                } else {
                    this.paginateData = [];
                    if(this.tareas.length < this.pageElements){
                        for (let index = 0; index < this.tareas.length; index++){
                            this.paginateData.push(this.tareas[index]);
                        }
                    } else {
                        for (let index = 0; index < this.pageElements; index++){
                            this.paginateData.push(this.tareas[index]);
                        }
                    }
                }
            } catch (error) {
                console.error('Error al cargar las tareas desde la API:', error);
            }
        },

        aplyFilter: async function (state, word) {
            const idSprint = localStorage.getItem("currentSprintId")
            const response = await AdminApi.GetAllTasks(idSprint);
            const TaskList = response.data.obj;
            this.tareas = TaskList;
            const filteredTasks = [];
            let success = false;
            
            for (const project of this.tareas) {
                const matchesState = (!state || project.Id_Status.toString() === state);
                const matchesWord = (!word || project.Task_Name.toLowerCase().includes(word.toLowerCase()) || project.Description_Task.toLowerCase().includes(word.toLowerCase()));

                if (matchesState && matchesWord) {
                    filteredTasks.push(project);
                    success = true;
                }
            }

            if ((!success && (state || word))) {
                this.paginateData = []
                this.paginate = false
                this.Filtros.fechaI = "";
                this.Filtros.fechaF = "";
                return
            }

            this.tareas = filteredTasks;
            await this.getTareasDesdeAPI();
            await this.cutPages();
            this.actualPage = 1;
            this.Filtros.fechaI = "";
            this.Filtros.fechaF = "";
        },

        totalPages: function () {
            return Math.ceil(this.tareas.length / this.pageElements)
        },

        changePage: async function (pageNum) {
            if(pageNum != "..."){
                this.paginateData = []
                if (pageNum == undefined){
                    pageNum = 1
                }
                this.actualPage = pageNum
                let ini = (pageNum * this.pageElements) - this.pageElements;
                let end = (pageNum * this.pageElements);
                let total = this.tareas.length;
                if(end < total){
                    for (let index = ini; index < end; index++){
                        this.paginateData.push(this.tareas[index]);
                    }
                } else{
                    for (let index = ini; index < total; index++){
                        this.paginateData.push(this.tareas[index]);
                    }
                }
                await this.cutPages();
            }
        },

        goBack: async function() {
            this.paginateData = []
            let paginaAnt = this.actualPage - 1
            this.actualPage = paginaAnt
            let ini = (paginaAnt * this.pageElements) - this.pageElements;
            let end = (paginaAnt * this.pageElements);
            let total = this.tareas.length;
            if(end < total){
                for (let index = ini; index < end; index++){
                    this.paginateData.push(this.tareas[index]);
                }
            } else{
                for (let index = ini; index < total; index++){
                    this.paginateData.push(this.tareas[index]);
                }
            }
            await this.cutPages();
        },

        goNext: async function() {
            this.paginateData = []
            let paginaAnt = this.actualPage + 1
            this.actualPage = paginaAnt
            let ini = (paginaAnt * this.pageElements) - this.pageElements;
            let end = (paginaAnt * this.pageElements);
            let total = this.tareas.length;
            if(end < total){
                for (let index = ini; index < end; index++){
                    this.paginateData.push(this.tareas[index]);
                }
            } else{
                for (let index = ini; index < total; index++){
                    this.paginateData.push(this.tareas[index]);
                }
            }
            await this.cutPages();
        },

        cutPages: async function () {
            let pages = []
            let numberOfPages = Math.ceil(this.tareas.length / this.pageElements)
            let actualPage = this.actualPage
            let numeration = 2
            let numerationSide = Math.floor(numeration / 2)
            let initialPage = 1
            let finalPage = numberOfPages

            if (numberOfPages > numeration) {

                if (actualPage > numerationSide) {

                    initialPage = actualPage - numerationSide

                    finalPage = actualPage + numerationSide

                } else {

                    initialPage = 1

                    finalPage = actualPage + numerationSide

                    finalPage += (numerationSide - (actualPage - 1))

                }

                if (finalPage > numberOfPages) {

                    finalPage = numberOfPages

                    initialPage = numberOfPages - numeration + 1

                }

            }

            for (let i = initialPage; i <= finalPage; i++) {

                pages.push(i)

            }

            if (actualPage > (numerationSide + 2)) { pages.unshift("...") }

            if (actualPage > (numerationSide + 1)) { pages.unshift(1) }

            if (

                (actualPage < (numberOfPages - numerationSide - 1)) &&

                numberOfPages != finalPage

            ) { pages.push("...") }

            if (

                (actualPage < (numberOfPages - numerationSide)) &&

                numberOfPages != finalPage

            ) { pages.push(numberOfPages) }

            this.pageNumeration = pages

            await this.validatePaginate();

        },

        validatePaginate: function () {
            let quantity = this.tareas.length
            if(quantity < 5){
                this.paginate = false
            } else {
                this.paginate = true
            }
        },

        async postTaskToAPI(tarea) {
            try {
                const response = await AdminApi.PostTask(tarea);
                if (response.data.ok) {
                    this.taskName = ''
                    this.taskDescription = ''
                    // caso exitoso para creacion de tarea
                    this.getTareasDesdeAPI(); // llamamos a get tareas
                } else {
                    console.log({ error : 'Error al crear la tarea' , response});
                }
            } catch (error) {
                console.error('Error al crear tarea', error);
            }
        }
    },

    mounted: async function() {
        this.$root.cerrarMenuFiltros = this.cerrarFiltros;
        let loader = this.$loading.show({
            container: this.$refs.cuadroLoader,
            opacity: 1
        })
                
        setTimeout(() => {
            loader.hide()
        }, 500)

        this.quill = new Quill(this.$refs.Quill, {
            theme: 'snow'
        })
    },

    created: async function () {
       
        await this.verificarLog();
        await this.getTareasDesdeAPI()
        await this.cutPages();
        await this.$root.validarLoginFooter.call();

        let urlParams = new URLSearchParams(window.location.search);
        this.currentSprintId = urlParams.get('id') || localStorage.getItem("currentSprintId");
    }

}

</script>

<style scoped>

#header {
    margin: auto;
    width: 500px;
    font-family: Arial, Helvetica, sans-serif;
}

ul, ol {
    list-style: none;
}

.nav > li {
    float: left;
}

.nav li a {
    background-color: #262b35;
    color: #fff;
    text-decoration: none;
    padding: 10px 12px;
    display: block;
}

    .nav li a:hover {
        color: #808080;
        background-color: #262b35;
    }

.nav li ul {
    display: none;
    position: absolute;
    min-width: 140px;
}

.nav li:hover > ul {
    display: block;
}

.nav li ul li {
    position: relative;
}

.nav li ul li ul {
    right: -140px;
    top: 0px;
}

.filtro {
    height: 3em;
    background: #000;
    border-radius: 0.5em;
}

    .filtro button {
        background-color: #000;
        border-radius: 0.5em;
        border: none;
    }

    .filtro button:hover {
        background-color: #000;
        border-radius: 0.5em;
        border: none;
        font-size: 15px;
    }

/*Select*/

.diseñoSelectLateral{
    height: 30px;
}

.diseñoSelect{
    height: 35px;
}

/*Select*/

.posicion0 {
    z-index: 0;
}

.posicion1 {
    z-index: 1;
    max-width: 280px;
    min-height: 95vh;
    background-color: #0a3a66;
    min-width: 15em;
    border-bottom: 1px solid white;
}

@media screen and (max-width: 900px) {
    .posicion1{
        display: none;
    }
}

@media screen and (max-width: 700px) {

    .responsiveCelular {
        min-height: 500px;
    }

    .menuLateralCelular{
        display: none;
    }
}

.filtrosCelular{
    padding-top: 20px;
    padding-left: 50px;
    padding-right: 50px;
    padding-bottom: 20px;
    background: rgba(10,58,102,1);
}

@media screen and (min-width: 901px) {

    .filtrosCelular{
        display: none;
    }
}

.encabezado {
    display: grid;
    grid-template-columns: 25% 50% 25%;
    background-color: #ffffff;
    color: rgb(0, 0, 0);
    min-height: 50px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    max-width: 1800px;
    margin-top: 25px;
}

    .encabezado ul {
            padding-top: 14px;
        }

    .li {
        font-family: sans-serif;
        color: black;
        text-decoration: none;
    }

    .encabezado div {
        text-align: center;
    }

.sinResultadosAct{
    width: 100%;
    text-align: center;
    margin-top: 30px;
    margin-bottom: 30px;
}

.contenidoTabla {
    max-width: 2100px;
    overflow-x: auto;
    margin-top: 25px;
}

.botones{
    min-height: 40px;
    min-width: 150px;
}

.agregarBlt{
    font-family: sans-serif;
    font-size: 18px;
    text-decoration: none;
    padding-right: 10px;
    position: relative;
    top: -5px;
    color: rgb(0, 0, 0);
}

@media screen and (max-width: 975px) {
    .agregarResponsive{
        display: none;
    }
}

@media screen and (min-width: 975px) {
    .agregarResponsivePlus{
        display: none;
    }
}

@media screen and (min-width: 901px) {
    .linkResponsive{
        display: none;
    }
}

@media screen and (max-width: 610px) {
    .linkResponsiveCelular{
        display: none;
    }
}

.filtrosCelularBoton{
    text-align: center;
    font-size: large;
    cursor: pointer;
    background-color: rgba(10,58,102,1);
    height: 30px;
    border-bottom-right-radius: 10px;
    border-bottom-left-radius: 10px;
    max-width: 50px;
}

@media screen and (min-width: 901px) {
    .filtrosCelularBotones{
        display: none;
    }

    .filtrosCelularBoton{
        display: none;
    }
}

.vistaPrincipal{
    min-height: 85vh;
}

@media screen and (max-width: 900px) {
    .vistaPrincipal{
        min-height: 98vh;
    }
}

@media screen and (max-width: 400px) {
    .vistaPrincipal{
        min-height: 100vh;
    }
}

.botonEncuestas{
    margin-left: -15px;
    min-width: 12.4rem;
    background-color: #114677;;
    min-height: 35px;
    border-radius: 5px;
    padding-top: 20px;
    list-style: none;
}

.textoEncuestas{
    margin-left: 25px;
    margin-top: -15px;
    font-size: 17px;
    text-decoration: none;
    color: white;
    display: block;
    position: relative;
}

.adjuntosJ {
    max-height: 240px;
    overflow-y: scroll;
    margin-bottom: 12px;
    margin-right: 1px;
    margin-left: 5px;
}

.inputsGeneral{
    border-radius: 15px;
}

.listaSubtareas{
    border: 1px solid #c5c5c5;
    border-radius: 15px;
}

.listaSubtareas:hover{
    background-color: #c5c5c5;
    cursor: pointer;
}

.tablaPersonalizada{
    display: grid;
    grid-template-columns: 10% 2% 48% 15% 25%;
    margin-bottom: 15px;
}

.tablaPersonalizadaSubtareas{
    display: grid;
    grid-template-columns: 10% 2% 48% 15% 25%;
}

@media screen and (max-width: 900px){
    .tablaPersonalizada{
        display: grid;
        grid-template-columns: 10% 3% 42% 20% 25%;
    }

    .tablaPersonalizadaSubtareas{
        display: grid;
        grid-template-columns: 10% 3% 42% 20% 25%;
    }
}

.tablaPersonalizada div {
    text-align: center;
}

.tablaPersonalizadaSubtareas{
    text-align: center;
}

.tablaPersonalizadaRow{
    font-size: large;
    cursor: pointer;
}

.tablaPersonalizadaRowSubTareas{
    font-size: medium;
    cursor: pointer;
}

.listadoSubtareas{
    background-color: #e7f3ff;
}

.listadoSubtareas:hover{
    background-color: #c7e0f7;
}

</style>