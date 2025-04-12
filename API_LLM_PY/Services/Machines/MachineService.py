from Data.MongoDB import db
"""
async def list_machine():
    machines = []
    cursor = db.machines.find()
    async for machine in cursor:
        machine['_id'] = str(machine['_id'])
        machines.append(machine)
    return machines

async def add_machine(machine):
    result = await db.machines.insert_one(machine.dict())
    return str(result.inserted_id)

async def get_machines_by_model(brand: str):
    machines = []
    cursor = db.machines.find({"brand": {"$regex": f"^{brand}$", "$options": "i"}})
    async for machine in cursor:
        machines.append(machine)

    if not machines:
        return f"Nenhuma máquina encontrada para a marca {brand}"

    response = f"Encontrei {len(machines)} maquinas(s) da marca {brand}:"
    for machine in machines:
        response += f"- Modelo: {machine['model']}, Descricao: {machine['description']}"

    return response
"""

async def list_machine():
    from Data.MongoDB import db  # <-- move a importação pra dentro
    machines = []
    cursor = db.machines.find()
    async for machine in cursor:
        machine['_id'] = str(machine['_id'])
        machines.append(machine)
    return machines

async def add_machine(machine):
    from Data.MongoDB import db
    result = await db.machines.insert_one(machine.dict())
    return str(result.inserted_id)

async def get_machines_by_model(brand: str):
    from Data.MongoDB import db
    machines = []
    cursor = db.machines.find({"brand": {"$regex": f"^{brand}$", "$options": "i"}})
    async for machine in cursor:
        machines.append(machine)

    if not machines:
        return f"Nenhuma máquina encontrada para a marca {brand}"

    response = f"Encontrei {len(machines)} maquina(s) da marca {brand}:"
    for machine in machines:
        response += f"\n- Modelo: {machine['model']}, Descrição: {machine['description']}"

    return response

