<template>
    <div>
        <!--<HeaderPrincipal :cuadroLoaderPrincipal="$refs.cuadroLoader" />-->
        <HeaderPrincipal />

        <div class="posicion0" v-on:click="cerrarMenu()">
            <div class="d-flex">

                <!------------------------------------------------Modales------------------------------------------------>

                <!--Modal crear Tarea-->

                <div v-if="modalShowTask" class="modal fade" id="staticBackdrop" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5"  id="exampleModalLabel">Crear Tarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Nombre<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="taskName" required style="border-radius: 5px;" type="text" maxLength="45" placeholder="Nombre">
                                    
                                    </div>
                                    <br>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div style="margin-top: 15px;">
                                                <input v-model="taskDescription" required style="border-radius: 5px;" type="textarea"  maxLength="100" placeholder="Descripción">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button @click="resetTaskCreation" type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="createTask" type="button" class="btn btn-success">Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal editar Tarea-->
                <div v-if="modalShowTask" class="modal fade" id="editarTarea" tabindex="-1" aria-labelledby="editarTarea" aria-hidden="true">
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
                                        <input v-model="taskNameUnderEdit" required @input="handleChanges" style="border-radius: 5px;" maxLength="45" type="text" placeholder="Nombre">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div>
                                                <input v-model="taskDescriptionUnderEdit" required @input="handleChanges" style="border-radius: 5px;" maxLength="100" type="textarea" placeholder="Descripcion...">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Estado<span style="color: red;"> *</span></label>
                                    <br />
                                    <!--:selected="currentTask?.Task_State === 'Finalizada'" -->
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="taskStateUnderEdit" required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;" @input="handleChanges">
                                            <option v-for="status in statusOptions" :key="status" :value="status">{{ status }}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button @click="editCurrentTask" type="button" class="btn btn-success">Aceptar</button>
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
                                    <label><strong>(Nota: <u>No se podrá volver a activar la tarea una vez
                                                completado</u>)</strong></label>
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
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal" >Cancelar</button>
                                <button @click="deleteRowList()"  :disabled="!confimPassworsDelete" class="btn btn-success">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Modal eliminar Tarea-->


                

                <!--Modal Ver Tarea-->

                <div class="modal fade" id="verTarea" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="verTarea" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-scrollable modal-xl">
                        <div class="modal-content">
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
                                                    <div style="text-align: center;">
                                                        {{ currentTask ? currentTask.Description_Task : '' }}
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br>

                                        <div class=" modal-footer   row justify-content-center" style="position: relative;">
                                            <!-- <div class="row justify-content-center" style="position: relative;">
                                                <button class="btn btn-success" v-if="currentTask ? currentTask.Id_Status != 'Finalizada' : false" style="width: 150px; min-height: 15px;" type="button" data-bs-dismiss="modal" @click="finishTask"><span class="fas fa-check"></span></button>
                                            </div> -->
                                        </div>

                                        <br />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal Ver Tarea-->

                <!-- Modal ver sub tarea-->
                
                <div class="modal fade" id="verSubTarea" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="verSubTarea" aria-hidden="true">
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
                                            <h1 style="text-align:center"><strong>{{ currentSubTask ? currentSubTask.Title : '' }}</strong></h1>
                                        </div>
                                    </div>
                                    <br/>
                                    <div class="row">
                                            <div class="col-12" style="text-align: right;">
                                                <p style="text-align: right;">Tiempo requerido: <b>{{ currentSubTask ? currentSubTask.Required_Time : 0.0 }}
                                                    </b> horas</p>
                                                    <p style="text-align: right;">Estado actual:<b>{{ currentSubTask ? currentSubTask.Id_Status : 0.0 }}</b></p>
                                            </div>
                                        </div>
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
                                                        {{ currentSubTask ? currentSubTask.Description : '' }}
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br>
                                        <div class=" modal-footer  row justify-content-center" style="position: relative;">
                                            <!-- <button v-if="currentSubTask ? currentSubTask.Id_Status != 'Finalizada' : false" style="width: 150px;color: white; background-color: green; min-height: 15px; min-width: 25px;" type="button" data-bs-dismiss="modal" @click="finishSubTask">Finalizar subtarea</button>
  -->
                                        </div>
                                        <br />
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <!-- final ver subtarea -->

                <!--Modal crear Subtarea-->
                <div v-if="modalShowSubTask" data-backdrop="static" data-keyboard="false" class="modal fade" id="crearSubtarea" tabindex="-1" aria-labelledby="crearSubtarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Crear Subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Título<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="tituloSubTarea" required style="border-radius: 5px;" type="text" maxLength="45" placeholder="Nombre">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div>
                                                <input v-model="descriptionSubTarea" required style="border-radius: 5px;" type="textarea" maxLength="100" placeholder="Descripción...">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Estado<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="statusSubTarea" required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option v-for="status in statusOptions" :key="status" :value="status">{{ status }}</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Tiempo requerido (horas)<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="requiredTimeSubTarea" required style="border-radius: 5px;" type="number" placeholder="1">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Prioridad<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="prioritySubTarea" required name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option v-for="priority in priorityOptions" :key="priority" :value="priority">{{priority}}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" @click="resetSubTaskCreation" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success" @click="createSubTask">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal crear Subtarea-->


                <!--Modal editar Subtarea-->

                <div v-if="modalShowSubTask" class="modal fade" id="editarSubtarea" tabindex="-1" aria-labelledby="editarSubtarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Editar Subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <label>Título<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="tituloSubTarea" required @input="handleChanges" style="border-radius: 5px;" type="text" maxLength="45" placeholder="Nombre">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div>
                                            <label class="margin-15px-bottom text-black">Descripción<span style="color: red;"> *</span></label>
                                            <div>
                                                <input v-model="descriptionSubTarea" @input="handleChanges" required style="border-radius: 5px;" type="textarea"  maxLength="100" placeholder="Descripción...">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Estado<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="statusSubTarea" required @input="handleChanges" name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option v-for="status in statusOptions" :key="status" :value="status">{{ status }}</option>
                                        </select>
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Tiempo requerido (horas)<span style="color: red;"> *</span></label>
                                    <br />
                                    <div style="margin-top: 15px;">
                                        <input v-model="requiredTimeSubTarea" required @input="handleChanges" style="border-radius: 5px;" type="number" min="1" placeholder="1">
                                    </div>
                                </div>
                                <br />
                                <div>
                                    <label>Prioridad<span style="color: red;"> *</span></label>
                                    <br />
                                    <div class="left-content" style="margin-top: 15px;">
                                        <select v-model="prioritySubTarea" required @input="handleChanges" name="estado" id="estado" class="form-select text-black inputsGeneral" style="min-height: 48px;">
                                            <option v-for="priority in priorityOptions" :key="priority" :value="priority">{{priority}}</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success" @click="editCurrentSubTask">Aceptar</button>
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
                                <button type="button" class="btn btn-success" data-bs-dismiss="modal" @click="deleteCurrentSubTask">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Modal eliminar Subtarea-->

                   <!-- Modal finalizar tarea -->

                   <div class="modal fade" id="finalizarTarea" tabindex="-1" aria-labelledby="finalizarTarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Finalizar tarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea finalizar la tarea?</p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success" data-bs-dismiss="modal" @click="() => finishTask()">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                  <!-- Modal finalizar tarea -->

                  <!-- Modal finalizar subtarea -->

                <div class="modal fade" id="finalizarSubTarea" tabindex="-1" aria-labelledby="finalizarSubTarea" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Finalizar subtarea</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <p>¿Está seguro de que desea finalizar la subtarea?</p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-success" data-bs-dismiss="modal" @click="() => finishSubTask()">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>

                  <!-- Modal finalizar subtarea -->

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

                        <div class="row" style="padding:15px; min-height: 95vh; padding-right: 45px; position: relative;">
                            <div class="col-12 estiloTabla tableHeight" style="padding:15px; margin-bottom: 10px;">
                                <div class="card" style="border: none;" ref="cuadroLoader">
                                    <div class="encabezado">
                                        <ul style="text-align: left;">
                                            <router-link class="li agregarBlt" role="button" :to="{ name: 'Sprints' }"><span class="fas fa-arrow-left"></span></router-link>
                                        </ul>
                                        <div style="text-align: center; padding-top: 10px; cursor: default;">
                                            <h4>Listado de Tareas</h4>
                                        </div>
                                        <ul style="text-align: right;">
                                            <a class="li agregarBlt agregarResponsive" @click="startTaskCreation" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span> Crear Tarea</a>
                                            <a class="li agregarBlt agregarResponsivePlus" @click="startTaskCreation" role="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><span class="fas fa-plus"></span></a>
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
                                                <div class="tablaPersonalizadaRow" @click="() =>mostrarSubtareas(tarea.Id_Task)" style="margin-bottom: 10px;">{{ tarea.Id_Task }}</div>
                                            </div>
                                            <div>
                                                <div class="tablaPersonalizadaRow" @click="() => startSubTaskCreation(tarea)" style="margin-bottom: 10px;"><a style="text-decoration: none;margin-bottom: 10px;" class="fas fa-plus" data-bs-toggle="modal" data-bs-target="#crearSubtarea"></a></div>
                                            </div>
                                            <div>
                                                <div class="tablaPersonalizadaRow" @click="() =>mostrarSubtareas(tarea.Id_Task)" style="margin-bottom: 10px;">{{ tarea.Task_Name }}</div>
                                            </div>
                                            <div>
                                                <div class="tablaPersonalizadaRow" @click="() =>mostrarSubtareas(tarea.Id_Task)" style="margin-bottom: 10px;">{{ tarea.Id_Status }}</div>
                                            </div>
                                            <div>
                                                <div class="tablaPersonalizadaRow" style="min-width: 150px; margin-bottom: 10px;">
                                                    <button  @click="() => selectCurrentTask(tarea)" class="btn btn-primary" role="button" data-bs-toggle="modal" data-bs-target="#verTarea">
                                                        <span class="fas fa-eye" b-tooltip.hover title="Ver Tarea"></span>
                                                    </button>
                                                    <button  @click="() => selectCurrentTask(tarea)" class="btn btn-success"  role="button" :disabled = "tarea.Id_Status == 'Finalizada'" style="margin-left: 5px;" data-bs-toggle="modal" data-bs-target="#finalizarTarea">
                                                        <span class="fas fa-check" b-tooltip.hover title="Finalizar"></span>
                                                    </button>
                                                    <button v-if="recuperarUsuTipo() == 'Administrador'" @click="() => startTaskEditing(tarea)" :disabled = "tarea.Id_Status == 'Finalizada'" style="margin-left: 5px;" type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#editarTarea">
                                                        <span class="fas fa-pen" b-tooltip.hover title="Editar Tarea"></span>
                                                    </button>
                                                    <button v-if="recuperarUsuTipo() == 'Administrador'" @click="() => deleteTask(tarea)" type="button" class="btn btn-danger" style="margin-left: 5px;" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                        <span class="fas fa-trash" b-tooltip.hover title="Eliminar Tarea"></span>
                                                    </button>
                                                </div>
                                            </div>

                                            <div 
                                                v-if="!subtareasPorTask[currentSelectedTaskId] || subtareasPorTask[currentSelectedTaskId].length == 0" 
                                                class="subtask-element sinResultadosAct listadoSubtareas"
                                                :style="`${subtareas && tarea.Id_Task == currentSelectedTaskId ? '' : 'display: none;'}`"
                                            >
                                                <div class="tablaPersonalizadaRowSubTareas">
                                                    <p>No hay subtareas para mostrar</p>
                                                </div>
                                                
                                            </div>

                                            <div 
                                                v-for="subTask in subtareasPorTask[currentSelectedTaskId]" 
                                                :key="subTask.Id_Sub_Task" 
                                                class="subtask-element tablaPersonalizadaSubtareas listadoSubtareas" 
                                                :style="`${subtareas && tarea.Id_Task == currentSelectedTaskId ? '' : 'display: none;'}`"
                                                :class="{ 'show': subtareas && tarea.Id_Task == currentSelectedTaskId}"
                                            >
                                                <div>
                                                    <div class="tablaPersonalizadaRow"></div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow" style="min-width: 75px;"></div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRowSubTareas">{{ subTask.Description }}</div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow">
                                                        <p class="fas" :class="`fa-${getPriorityIcon(subTask.Id_Priority)}-circle`" :style="`color: ${getPriorityColor(subTask.Id_Priority)};`"></p>
                                                    </div>
                                                </div>
                                                <div>
                                                    <div class="tablaPersonalizadaRow" style="min-width: 200px;">
                                                        <a style="text-decoration: none; margin-right: 20px;" 
                                                            class="fas fa-eye" b-tooltip.hover 
                                                            title="Ver subtarea" 
                                                            data-bs-toggle="modal" 
                                                            data-bs-target="#verSubTarea" 
                                                            @click="() => selectCurrentSubTask(subTask)"
                                                        ></a>
                                                        <a style="text-decoration: none; margin-right: 20px; " 
                                                            :style="subTask.Id_Status == 'Finalizada' ? 'cursor: not-allowed' : ''" 
                                                            class="fas fa-check" 
                                                            data-bs-toggle="modal" 
                                                            :data-bs-target=" subTask.Id_Status == 'Finalizada' ? '' : '#finalizarSubTarea'" 
                                                            @click="() => subTask.Id_Status == 'Finalizada' ? null :selectCurrentSubTask(subTask)"
                                                        ></a>
                                                        <a style="text-decoration: none; margin-right: 20px;" 
                                                            :style="subTask.Id_Status == 'Finalizada' ? 'cursor: not-allowed' : ''" 
                                                            class="fas fa-pen" 
                                                            data-bs-toggle="modal" 
                                                            :data-bs-target=" subTask.Id_Status == 'Finalizada' ? '' : '#editarSubtarea'" 
                                                            @click="subTask.Id_Status == 'Finalizada' ? null : startSubTaskEditing(subTask)"
                                                        ></a>
                                                        <a style="text-decoration: none;" 
                                                            class="fas fa-trash"
                                                            data-bs-toggle="modal" 
                                                            data-bs-target="#eliminarSubtarea" 
                                                            @click="() => selectCurrentSubTask(subTask)"
                                                         ></a>
                                                    </div>
                                                </div>
                                               
                                            </div>
                                                    
                                        </div>

                                            <br/>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                
                            <nav v-if="paginate" aria-label="Page navigation example" style="margin-top: 10px;">
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

            pageElements: 10,
            actualPage: 1,
            pageNumeration: [],
            paginate: true,
            paginateData: [],

            subtareas: false,
            tareas : [],
            currentSubTask : null,
            currentTask: null,
            currentSelectedTaskId : null,

            // opciones para estados y prioridades
            statusOptions : [],
            priorityOptions : [],

            taskName: '',
            taskDescription: '',
            verifyPassword:"",

            // campos de edicion
            taskNameUnderEdit : '',
            taskDescriptionUnderEdit : '',
            taskStateUnderEdit : '',
            taskIdUnderEdit : null,

            // campos edicion subtarea
            prioritySubTarea : '',
            tituloSubTarea : '',
            descriptionSubTarea : '',
            statusSubTarea : '',
            requiredTimeSubTarea : 0,

            // validacion de tarea
            validationMessage : '',
            confimPassworsDelete : '',

            currentSprintId : 0,

            subtareasPorTask : { },


            modalShowTask : false,
            modalShowSubTask : false
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
                Task_Name : this.taskNameUnderEdit.trim(),
                Description_Task : this.taskDescriptionUnderEdit.trim(),
                // los que no cambian
                Id_Task : this.taskIdUnderEdit,
                Id_Sprint: localStorage.getItem('currentSprintId'),
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
                this.modalShowTask = false
                this.$swal({ icon: 'success', showConfirmButton:false, text: 'Se modifico correctamente la tarea' });
                this.tareas = [];
                this.getTareasDesdeAPI(); 

                 setTimeout(() => {
                    location.reload();
                }, 1000);

            } else {
                console.error({message : "Hubo un error al editar tarea", result});
            }
        },


        async editCurrentSubTask() {
            const subTaskId = this.currentSubTask.Id_Sub_Task;
            const subTask = {
                Id_Sub_Task : subTaskId,
                Title : this.tituloSubTarea.trim(),
                Description : this.descriptionSubTarea.trim(),
                Required_Time : this.requiredTimeSubTarea,
                Id_Task : this.currentSelectedTaskId,
                Id_Priority : this.prioritySubTarea,
                Id_Status : this.statusSubTarea
            }

            if (this.validateSubTask(subTask, true) !== 'VALID') {
                return;
            }
            
            const result = await AdminApi.PutSubTask(subTask);
            if (result.data.ok) {

                // limpiar campos
                this.prioritySubTarea = '';
                this.tituloSubTarea = '';
                this.descriptionSubTarea = '';
                this.statusSubTarea = '';
                this.requiredTimeSubTarea = 0;
                this.modalShowSubTask = false
                this.$swal({ icon: 'success', showConfirmButton:false, text: 'Se modifico correctamente la subtarea' });

                this.getSubTareasDesdeAPI(this.currentSelectedTaskId);

                setTimeout(() => {
                    location.reload();
                }, 1000);

            } else {
                console.error({message : "Hubo un error al editar subtarea", result});
            }
        },

        getPriorityIcon(priority) {
            if (priority == 'Alta') return 'exclamation'
            if (priority == 'Media') return 'info'
            if (priority == 'Baja') return 'check'
            return 'warning'
        },

        getPriorityColor(priority) {
            if (priority == 'Alta') return 'red'
            if (priority == 'Media') return 'blue'
            if (priority == 'Baja') return 'green'
            return 'gray'
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
              console.error({message :'Error al cargar las tareas desde la API:', error});
          }

      },

        validateTask(task, isEdit) {

            if (task.Task_Name.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del nombre de la tarea',
                })
            }

            if (task.Description_Task.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo de la descripción de la tarea',
                })
            }

            const validStates = [ "Pendiente", "En Proceso", "Finalizada" ]
            if (isEdit && !validStates.includes(task.Id_Status.trim())) {
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del estado de la tarea',
                })
            }   

            if (isEdit && !this.hasChanges) {
                return this.$swal.fire({
                    position: 'center',
                    icon: 'warning',
                    title: '¡No se realizó ningún cambio!',
                });
            }

            return 'VALID';
        },

        validateSubTask(subTask, isEdit) {

            if (subTask.Title.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del titulo de la subtarea',
                })
            }

            if (subTask.Description.trim() == "") {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo de la descripción de la subtarea',
                })
            }

            const validStates = [ "Pendiente", "En Proceso", "Finalizada" ]
            if (isEdit && !validStates.includes(subTask.Id_Status.trim())) {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo del estado de la subtarea',
                })
            }

            if (subTask.Required_Time === "" || subTask.Required_Time <= 0) {
                
                return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'El tiempo de la subtarea es requerido y debe ser mayor a 0',
                })
            }

            const validPriorities = [ "Alta", "Media", "Baja" ]
            if (isEdit && !validPriorities.includes(subTask.Id_Priority.trim())) {
                
               return this.$swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: '¡Error!',
                    text: 'Se tiene que completar el campo de la prioridad de la subtarea',
                })
            }

            if (isEdit && !this.hasChanges) {
                return this.$swal.fire({
                    position: 'center',
                    icon: 'warning',
                    title: '¡No se realizó ningún cambio!',
                });
            }

            return 'VALID';
        },


        async finishSubTask(subTask) {
            subTask = subTask == null ? this.currentSubTask : subTask;
            const selectedCurrentTaskid = subTask.Id_Task || this.currentSubTask.Id_Task;
            const selectedCurrentSubTaskid = subTask.Id_Sub_Task || this.currentSubTask.Id_Sub_Task;

            const response = await AdminApi.PutSubTaskAsFinished(selectedCurrentSubTaskid);
            if (response.data.ok) {
                this.$swal({ icon: 'success', text: 'Se finalizó la subtarea' });
                this.getSubTareasDesdeAPI(selectedCurrentTaskid);
            } else {
                this.$swal({icon: 'error', text: 'No se pudo finalizar la subtarea' });
                console.error({message : "Error al finalizar subtarea", response })
            }
        },

        async finishTask(taskId) {
            const selectedCurrentTaskid = taskId || this.currentTask.Id_Task;

            const response = await AdminApi.PutTaskAsFinished(selectedCurrentTaskid);
            if (response.data.ok) {
                this.tareas = [];
                this.$swal({ icon: 'success', text: 'Se finalizó la tarea' });
                this.getTareasDesdeAPI(selectedCurrentTaskid);
            } else {
                this.$swal({icon: 'error', text: 'No se pudo finalizar la tarea' });
                console.error({message : "Error al finalizar tarea", response })
            }
        },

        async deleteTask(task) {
            this.currentTask = task
        },

        mostrarSubtareas: function(taskId) {
            this.getSubTareasDesdeAPI(taskId)
            this.currentSelectedTaskId = taskId;
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
            this.modalShowTask = true;
            this.selectCurrentTask(task);

            // cargar los campos para edicion
            this.taskIdUnderEdit = task.Id_Task;
            this.taskDescriptionUnderEdit = task.Description_Task;
            this.taskStateUnderEdit = task.Id_Status,
            this.taskNameUnderEdit = task.Task_Name
        },

        startTaskCreation() {
            this.modalShowTask = true;
        },

        startSubTaskEditing(subTask) {
            this.modalShowSubTask = true;
            this.selectCurrentSubTask(subTask);

            // cargar los campos para edicion
            this.prioritySubTarea = subTask.Id_Priority;
            this.tituloSubTarea = subTask.Title;
            this.descriptionSubTarea = subTask.Description,
            this.statusSubTarea = subTask.Id_Status
            this.requiredTimeSubTarea = subTask.Required_Time
        },

        startSubTaskCreation(task) {
            this.modalShowSubTask = true;
            this.currentSelectedTaskId = task.Id_Task;

            // reset de campos
            this.prioritySubTarea = '';
            this.tituloSubTarea = '';
            this.descriptionSubTarea = '';
            this.statusSubTarea = '';
            this.requiredTimeSubTarea = 0;
        },

        selectCurrentTask(task) {
            this.currentTask = task;
        },

        selectCurrentSubTask(subTask) {
            this.currentSubTask = subTask;
        },

        async deleteCurrentSubTask() {
            const subTaskId = this.currentSubTask.Id_Sub_Task;

            const response = await AdminApi.PutSubTaskDisableStatus(subTaskId);
            if (response.data.ok) {
                this.currentSubTask = null;
                this.$swal({ icon: 'success', text: 'Se elimino la subtarea' });
                this.getSubTareasDesdeAPI(this.currentSelectedTaskId);
            } else {
                this.$swal({icon: 'error', text: 'No se pudo eliminar la subtarea' });
            }
        },

        recuperarUsuLog() {
            return Cookies.get("usuarioLogin")
        },

        getPasswordVerifyDeleteRow: async function () {
            let login = this.recuperarUsuLog()
            try {
                const response = await AdminApi.GetPasswordVerifyDeleteRow(login, this.verifyPassword);
                const mensage=response.data.ok;
                if(mensage==true){

                this.confimPassworsDelete=true
                this.$swal({ icon: 'success', text: 'Se verifico correctamente la contraseña' });
                    
                }
                else{
                    this.$swal({ position: 'center', icon: 'warning', text: 'Contraseña Incorrecta' });

                }

            } catch (error) {
                console.error({message : 'Error al cargar los proyectos desde la API:', error});
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
            this.resetTaskCreation();
            this.tareas = []
            await this.getTareasDesdeAPI()
            await this.cutPages()
        },

        resetTaskCreation() {
            this.taskName = ''
            this.taskDescription = ''
        },

        createSubTask() {
            const subTask = {
                Title : this.tituloSubTarea.trim(),
                Description : this.descriptionSubTarea.trim(),
                Required_Time : this.requiredTimeSubTarea,
                Id_Task : this.currentSelectedTaskId,
                Id_Priority : this.prioritySubTarea,
                Id_Status : this.statusSubTarea
            }

            if (this.validateSubTask(subTask, true) !== 'VALID') {
                return;
            }

            this.postSubTaskToAPI(subTask);
            this.resetSubTaskCreation();
            this.getSubTareasDesdeAPI(this.currentSelectedTaskId);
        },

        resetSubTaskCreation() {
            this.tituloSubTarea = '',
            this.descriptionSubTarea = ''
            this.requiredTimeSubTarea = 0
            this.prioritySubTarea = ''
            this.statusSubTarea = ''
        },

        async getTareasDesdeAPI() {
            const idSprint = localStorage.getItem("currentSprintId")
            this.actualPage = 1
            try {
                if (this.tareas.length == 0) {
                    const response = await AdminApi.GetAllTasksBySprint(idSprint);
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
                console.error({message: 'Error al cargar las tareas desde la API:', error});
            }
        },

        aplyFilter: async function (state, word) {
            const idSprint = localStorage.getItem("currentSprintId")
            const response = await AdminApi.GetAllTasksBySprint(idSprint);
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
            if (this.actualPage > 1){
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
            }
        },

        goNext: async function() {
            if (this.actualPage == this.pageNumeration.length || this.actualPage > this.pageNumeration.length) {
                return
            } else {
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
            }
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
            if(quantity < 11){
                this.paginate = false
            } else {
                this.paginate = true
            }
        },

        async getSubTareasDesdeAPI(taskId) {
            try {
                const response = await AdminApi.GetAllSubTasksByTask(taskId);
                const subTasks = response.data.obj;
                this.subtareasPorTask[taskId] = subTasks;
            } catch (error) {
                console.error({message: 'Error al cargar las subtareas desde la API:', error, response});
            }
        },

        async postTaskToAPI(tarea) {
            try {
                const response = await AdminApi.PostTask(tarea);
                if (response.data.ok) {
                    this.taskName = ''
                    this.taskDescription = ''
                    // caso exitoso para creacion de tarea
                    this.modalShowTask = false
                    
                    const swal = this.$swal({
                            title: 'Se creo correctamente la tarea',
                            icon:'success',
                            showConfirmButton:false,
                        });
                    this.getTareasDesdeAPI(); // llamamos a get tareas

                    setTimeout(() => {
                        swal.close();
                        location.reload();
                    }, 1000);
                } else {
                    console.error({ message : 'Error al crear la tarea' , response});
                }
            } catch (error) {
                console.error({ message :'Error al crear tarea', error});
            }
        },

        async postSubTaskToAPI(subTarea) {
            try {
                const response = await AdminApi.PostSubTask(subTarea);
                if (response.data.ok) {

                    this.taskName = ''
                    this.taskDescription = ''
                    // caso exitoso para creacion de subtarea
                    const taskId = subTarea.Id_Task;
                    this.modalShowSubTask = false

                    const swal = this.$swal({
                            title: 'Se creo correctamente la subtarea',
                            icon:'success',
                            showConfirmButton:false,
                        });
                    this.getSubTareasDesdeAPI(taskId); // llamamos a get subtareas

                    setTimeout(() => {
                        swal.close();
                        location.reload();
                    }, 1000);
                } else {
                    console.error({ message : 'Error al crear la subtarea' , response});
                }
            } catch (error) {
                console.error({ message :'Error al crear subtarea', error});
            }
        },
        
        async getAllOptions() {
            const responseStatus = await AdminApi.GetAllStatus();
            if (responseStatus.data.ok) {
                this.statusOptions = responseStatus.data.obj.filter(status => status != 'Activo' && status != 'Inactivo');
            }

            const responsePriorities = await AdminApi.GetAllPriorities();
            if (responsePriorities.data.ok) {
                this.priorityOptions = responsePriorities.data.obj;
            }
        },

        handleChanges() {
            this.hasChanges = true;
        },
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
        await this.getAllOptions();
        await this.getTareasDesdeAPI()
        await this.cutPages();
        await this.$root.validarLoginFooter.call();

        let urlParams = new URLSearchParams(window.location.search);
        this.currentSprintId = urlParams.get('id') || localStorage.getItem("currentSprintId");
    }

}

</script>

<style scoped>


.cell-subtask {
    margin-bottom: 15px;
    background-color: #418ebb;
    color: white;
    border-color: black;
}

.tablaPersonalizadaRowSubtask {
    flex: 1;
}

.subtask-element {
    grid-column-start: 1;
    grid-column-end: 6;
    margin-bottom: 15px;
    display: flex;
    justify-content: space-evenly;
    color: black;
}

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
    overflow-x: auto !important;
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

.tablaPersonalizada {
    display: grid;
    grid-template-columns: 10% 5% 48% 15% 25%;
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
    margin-left: 50px;
}

.listadoSubtareas{
    background-color: #e7f3ff;
}

.listadoSubtareas:hover{
    background-color: #c7e0f7;
}

</style>