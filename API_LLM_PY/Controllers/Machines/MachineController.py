from fastapi import APIRouter

from Entities.Machines.Machines import Machines, MachineCreate
from Services.Machines.MachineService import list_machine, add_machine, get_machines_by_model

router = APIRouter()

@router.get("/GetMachines")
async def get_machines():
    return await list_machine()

@router.post("/AddMachines")
async def post_machine(machine: MachineCreate):
    machine_id = await add_machine(machine)
    return {"id": machine_id}

@router.get("GetMachinesPrompt/{marca}")
async def get_machines_by_brand_endpoint(marca: str):
    return await get_machines_by_model(marca)
