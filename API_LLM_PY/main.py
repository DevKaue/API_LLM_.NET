from fastapi import FastAPI

from Controllers.Machines.MachineController import router as machine_router
from Data.MongoDB import connect_to_mongo, close_mongo_connection

app = FastAPI()

# Eventos para conectar/desconectar do MongoDB
@app.on_event("startup")
async def startup_db():
    await connect_to_mongo()

@app.on_event("shutdown")
async def shutdown_db():
    await close_mongo_connection()

# Rotas
app.include_router(machine_router, prefix="/machines", tags=["Machines"])

@app.get("/")
async def root():
    return {"message": "API FastAPI com MongoDB"}