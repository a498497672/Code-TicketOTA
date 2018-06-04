using Ticket.Core.Repository;

namespace Ticket.Core.Service
{
    /// <summary>
    /// 闸机
    /// </summary>
    public class DoorGateService
    {
        private readonly DoorGateRepository _doorGateRepository;
        private readonly TicketDoorGateRepository _ticketDoorGateRepository;

        public DoorGateService(DoorGateRepository doorGateRepository, TicketDoorGateRepository ticketDoorGateRepository)
        {
            _doorGateRepository = doorGateRepository;
            _ticketDoorGateRepository = ticketDoorGateRepository;
        }
        /// <summary>
        /// 检测闸机是否可用
        /// </summary>
        /// <param name="doorGateNo">闸机号</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckDoorGate(string doorGateNo, out string msg)
        {
            msg = string.Empty;
            var entity = _doorGateRepository.FirstOrDefault(a => a.DoorGateNO.Trim().Equals(doorGateNo.Trim()));
            if (entity == null)
            {
                msg = "设备不存在";
                return false;
            }
            if (entity.DataStatus != 0)
            {
                msg = "设备已禁用";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检测指定闸机是否可用
        /// </summary>
        /// <param name="ticketId">门票Id</param>
        /// <param name="doorGateNo">闸机号</param>
        /// <returns></returns>
        public bool CheckTicketDoorGate(int ticketId, string doorGateNo)
        {
            var doorGateIds = _ticketDoorGateRepository.FindByDoorGateIds(ticketId);
            var doorGate = _doorGateRepository.FirstOrDefault(a => a.DoorGateNO.Trim().Equals(doorGateNo.Trim()) && doorGateIds.Contains(a.DoorGateId));
            if (doorGate == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="doorGateNo">闸机号</param>
        /// <returns></returns>
        public int GetScenicGateId(string doorGateNo)
        {
            var entity = _doorGateRepository.FirstOrDefault(a => a.DoorGateNO == doorGateNo);
            if (entity == null)
            {
                return 0;
            }
            return entity.ScenicGateId ?? 0;
        }
    }
}
